using MagniFinance.Domain.Entities;
using MagniFinance.Domain.Interfaces;
using MagniFinance.Web.Hubs;
using MagniFinance.Web.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MagniFinance.Web.Controllers
{
    public class TeacherController : Controller
    {

        private IBaseService<Teacher> _service;

        public TeacherController(IBaseService<Teacher> service)
        {
            _service = service;
        }

        public ActionResult Teachers()
        {
            return View();
        }
        public ActionResult Form()
        {
            return View();
        }

        public async Task<JsonResult> TeacherList()
        {
            var teacherList = await _service.GetAll();
            var result = teacherList.Select(x => TeacherDTO.Mapper(x));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateTeacher(Teacher teacher)
        {
            string message = string.Empty;
            if (!ModelState.IsValid)
            {
                message = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                return Json(message, JsonRequestBehavior.AllowGet);

            }
            else
            {
                var result = _service.Add(teacher);
                if (result)
                {
                    var _context = GlobalHost.ConnectionManager.GetHubContext<TeacherHub>();
                    _context.Clients.All.addNewTeacher(teacher);
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult UpdateTeacher(Teacher teacher)
        {
            string message = string.Empty;
            if (!ModelState.IsValid)
            {
                message = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = _service.Update(teacher);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> GetTeacher(Guid id)
        {
            Teacher result = await _service.Get(id);
            return Json(TeacherDTO.Mapper(result), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteTeacher(Guid id)
        {
            bool result = _service.Delete(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}