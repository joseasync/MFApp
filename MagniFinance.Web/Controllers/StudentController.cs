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
    public class StudentController : Controller
    {

        private IBaseService<Student> _service;

        public StudentController(IBaseService<Student> service)
        {
            _service = service;
        }

        public ActionResult Students()
        {
            return View();
        }
        public ActionResult Form()
        {
            return View();
        }

        public async Task<JsonResult> StudentList()
        {
            var studentList = await _service.GetAll();
            var result = studentList.Select(x => StudentDTO.Mapper(x));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> StudentListView()
        {
            var studentList = await _service.GetAll();
            var result = studentList.SelectMany(x => StudentDTO.MapperList(x));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateStudent(Student student)
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
                var result = _service.Add(student);

                var _context = GlobalHost.ConnectionManager.GetHubContext<StudentHub>();
                _context.Clients.All.addNewStudent(student);

                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult UpdateStudent(Student student)
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
                var result = _service.Update(student);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> GetStudent(Guid id)
        {
            Student result = await _service.Get(id);
            return Json(StudentDTO.Mapper(result), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteStudent(Guid id)
        {
            bool result = _service.Delete(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}