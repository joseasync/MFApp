using MagniFinance.Domain.Entities;
using MagniFinance.Domain.Interfaces;
using MagniFinance.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MagniFinance.Web.Controllers
{
    public class CourseController : Controller
    {

        private ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }

        public ActionResult Courses()
        {
            return View();
        }
        public ActionResult Form()
        {
            return View();
        }

        public async Task<JsonResult> CourseList()
        {
            var courseList = await _service.GetAll();
            var result = courseList.Select(x => CourseDTO.Mapper(x));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateCourse(Course course)
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
                var result = _service.Add(course);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult UpdateCourse(Course course)
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
                var result = _service.Update(course);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> GetCourse(Guid id)
        {
            Course result = await _service.Get(id);
            return Json(CourseDTO.Mapper(result), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCourse(Guid id)
        {
            bool result = _service.Delete(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}