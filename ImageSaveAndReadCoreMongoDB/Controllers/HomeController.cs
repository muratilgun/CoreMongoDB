using System;
using System.IO;
using ImageSaveAndReadCoreMongoDB.IRepository;
using ImageSaveAndReadCoreMongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ImageSaveAndReadCoreMongoDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository = null;
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string SaveFile(FileUpload fileobj)
        {
            Employee emp = JsonConvert.DeserializeObject<Employee>(fileobj.Employee);
            if (fileobj.File.Length> 0)
            {
                using (var ms = new MemoryStream())
                {
                    fileobj.File.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    emp.Photo = fileBytes;
                    emp = _employeeRepository.Save(emp);
                    if (emp.Id.Trim() != "")
                    {
                        return "Saved";
                    }
                }
            }

            return "Failed";
        }

        [HttpGet]
        public JsonResult GetSavedEmployee()
        {
            var emp = _employeeRepository.GetSaveEmployee();
            emp.Photo = this.GetImage(Convert.ToBase64String(emp.Photo));
            return Json(emp);
        }

        private byte[] GetImage(string sBase64String)
        {
            byte[] bytes = null;
            if (!string.IsNullOrEmpty(sBase64String))
            {
                bytes = Convert.FromBase64String(sBase64String);
            }

            return bytes;
        }
    }
}
