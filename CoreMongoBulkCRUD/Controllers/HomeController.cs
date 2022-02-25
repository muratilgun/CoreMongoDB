﻿using CoreMongoBulkCRUD.Models;
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
