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
    public class GradeController : Controller
    {

        private IBaseService<Grade> _service;

        public GradeController(IBaseService<Grade> service)
        {
            _service = service;
        }

        public ActionResult Grades()
        {
            return View();
        }
        public ActionResult Form()
        {
            return View();
        }

        public async Task<JsonResult> GradeList()
        {
            var gradeList = await _service.GetAll();
            var result = gradeList.Select(x => GradeDTO.Mapper(x));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateGrade(Grade grade)
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
                var result = _service.Add(grade);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult UpdateGrade(Grade grade)
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
                var result = _service.Update(grade);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> GetGrade(Guid id)
        {
            Grade result = await _service.Get(id);
            return Json(GradeDTO.Mapper(result), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteGrade(Guid id)
        {
            bool result = _service.Delete(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}