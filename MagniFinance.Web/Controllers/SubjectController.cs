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
    public class SubjectController : Controller
    {

        private IBaseService<Subject> _service;

        public SubjectController(IBaseService<Subject> service)
        {
            _service = service;
        }

        public ActionResult Subjects()
        {
            return View();
        }
        public ActionResult Form()
        {
            return View();
        }

        public async Task<JsonResult> SubjectList()
        {
            var subjectList = await _service.GetAll();
            var result = subjectList.Select(x => SubjectDTO.Mapper(x));

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateSubject(Subject subject)
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
                var result = _service.Add(subject);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult UpdateSubject(Subject subject)
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
                var result = _service.Update(subject);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> GetSubject(Guid id)
        {
            Subject result = await _service.Get(id);
            return Json(SubjectDTO.Mapper(result), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteSubject(Guid id)
        {
            bool result = _service.Delete(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}