﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DotNetCoreAuthentication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotNetCoreAuthentication.Models;
using DotNetCoreAuthentication.Repository;
using DotNetCoreAuthentication.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;


namespace DotNetCoreAuthentication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMailBoxService _service;

        public HomeController(ILogger<HomeController> logger,IMailBoxService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {

            var userid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return View(await _service.GetAllAsync(userid));
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
