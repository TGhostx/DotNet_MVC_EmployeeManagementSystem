using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.DTOs.Job;
using EMS.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EMS.Web.Controllers
{
    [Route("[controller]")]
    public class JobController : Controller
    {
        private readonly IJobService _service;

        public JobController(IJobService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var jobs = await _service.GetAllAsync();
            return View(jobs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateJobDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _service.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}