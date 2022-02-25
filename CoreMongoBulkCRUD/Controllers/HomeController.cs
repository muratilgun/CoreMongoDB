using CoreMongoBulkCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoreMongoBulkCRUD.IRepository;

namespace CoreMongoBulkCRUD.Controllers
{
    public class HomeController : Controller
    {
  
        public IEmployeeRepository _employeeRepository = null;

        public HomeController(IEmployeeRepository employeeRepository)
        {
           _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult BulkSave()
        {
            _employeeRepository.BulkSave();
            return null;
        }
        [HttpPut]
        public JsonResult BulkUpdate()
        {
            _employeeRepository.BulkUpdate();
            return null;
        }
        [HttpDelete]
        public JsonResult BulkDelete()
        {
            _employeeRepository.BulkDelete();
            return null;
        }
        [HttpDelete]
        public JsonResult BulkDeleteByPropertyValue()
        {
            _employeeRepository.BulkDeleteByPropertyValue();
            return null;
        }
    }
}
