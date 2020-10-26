using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetCoreAuthentication.Data;
using DotNetCoreAuthentication.Models;
using DotNetCoreAuthentication.Repository;
using DotNetCoreAuthentication.Service;
using DotNetCoreAuthentication.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace DotNetCoreAuthentication.Controllers
{
    [Authorize]
    public class MailBoxesController : Controller
    {
        private readonly IMailBoxService _service;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public MailBoxesController(IMailBoxService service , IMapper mapper, IEmailSender emailSender)
        {
            _service = service;
            _mapper = mapper;
            _emailSender = emailSender;
        }
        
        // GET: MailBoxes
        public async Task<IActionResult> Index()
        {
            var userid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return View(await _service.GetAllAsync(userid));
        }

        // GET: MailBoxes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var mailBox = await _service.GetMailsById(id);
            var model = _mapper.Map<MailBoxDto>(mailBox);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // GET: MailBoxes/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sender,Receiver,Subject,Message,DateTime")] MailBoxDto model)
        {
            if (ModelState.IsValid)
            {
                var userid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var mailBox = _mapper.Map<MailBox>(model);
                mailBox.DateTime = DateTime.Now;
                var user = HttpContext.User.FindFirst(ClaimTypes.Name).Value;
                mailBox.UserId = userid;
                mailBox.Sender = user;
                mailBox.CreatedAt = DateTime.Now;
                await _service.AddMailAsync(mailBox);
                await _emailSender.SendEmailAsync(mailBox.Receiver, mailBox.Subject, mailBox.Message);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: MailBoxes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mailBox = await _service.GetMailsById(id);
            var model = _mapper.Map<MailBoxDto>(mailBox);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sender,Receiver,Subject,Message,DateTime")] MailBoxDto model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                var mailBox = _mapper.Map<MailBox>(model);
                var userid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                mailBox.UserId = userid;
                mailBox.UpdatedAt = DateTime.Now;
                mailBox.DateTime = DateTime.Now;
                await _service.UpdateMailAsync(mailBox);
                await _emailSender.SendEmailAsync(mailBox.Receiver, mailBox.Subject, mailBox.Message);


                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: MailBoxes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mailBox = await _service.GetMailsById(id);
            if (mailBox == null)
            {
                return NotFound();
            }

            return View(mailBox);
        }

        // POST: MailBoxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
             await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

  
    }
}
