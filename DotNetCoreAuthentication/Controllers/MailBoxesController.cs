using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetCoreAuthentication.Data;
using DotNetCoreAuthentication.Models;
using DotNetCoreAuthentication.Repository;
using DotNetCoreAuthentication.Service;
using Microsoft.AspNetCore.Http;

namespace DotNetCoreAuthentication.Controllers
{
    public class MailBoxesController : Controller
    {
        private readonly IMailBoxService _service;
        

        public MailBoxesController(IMailBoxService service)
        {
            _service = service;
            
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
            var userid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var mailBox = await _service.GetMailsById(id);
            if (mailBox == null)
            {
                return NotFound();
            }

            return View(mailBox);
        }

        // GET: MailBoxes/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sender,Receiver,Subject,Message,DateTime")] MailBox mailBox)
        {
            if (ModelState.IsValid)
            {
                var userid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                mailBox.DateTime = DateTime.Now;
                var user = HttpContext.User.FindFirst(ClaimTypes.Name).Value;
                mailBox.UserId = userid;
                mailBox.Sender = user;
                mailBox.CreatedAt = DateTime.Now;
                await _service.AddMailAsync(mailBox);
                return RedirectToAction(nameof(Index));
            }
            return View(mailBox);
        }

        // GET: MailBoxes/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sender,Receiver,Subject,Message,DateTime")] MailBox mailBox)
        {
            if (id != mailBox.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var userid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    mailBox.UserId = userid;
                    mailBox.UpdatedAt = DateTime.Now;
                    await _service.UpdateMailAsync(mailBox);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (mailBox.Id == 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mailBox);
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
