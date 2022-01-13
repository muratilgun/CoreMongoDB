using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMongoDB.IRepository;
using CoreMongoDB.Models;

namespace CoreMongoDB.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployeeRepository _employeeRepository = null;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetEmployees()
        {
            var employees = _employeeRepository.Gets();
            return Json(employees);
        }

        public JsonResult SaveEmp(Employee employee)
        {
            var employees = _employeeRepository.Save(employee);
            return Json(employees);
        }
        public JsonResult DeleteEmp(string empId)
        {
            string message = _employeeRepository.Delete(empId);
            return Json(message);
        }

    }
}
