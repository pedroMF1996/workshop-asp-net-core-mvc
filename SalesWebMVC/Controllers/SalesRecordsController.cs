﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SalesWebMVC.Controllers
{
    public class SalesRecordsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch()
        {

            return View();
        }

        public async Task<IActionResult> GroupingSearch()
        {
            return View();
        }
    }
}