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
using Microsoft.AspNetCore.Http;

namespace DotNetCoreAuthentication.Controllers
{
    public class MailBoxesController : Controller
    {
        private readonly DotNetCoreAuthenticationContext _context;
        

        public MailBoxesController(DotNetCoreAuthenticationContext context)
        {
            _context = context;
            
        }
        
        // GET: MailBoxes
        public async Task<IActionResult> Index()
        {
            var userid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return View(await _context.MailBoxes.Where(x => x.UserId == userid).ToListAsync());
        }

        // GET: MailBoxes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var mailBox = await _context.MailBoxes
                .FirstOrDefaultAsync(m => m.Id == id && m.UserId == userid);
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

        // POST: MailBoxes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sender,Receiver,Subject,Message,DateTime")] MailBox mailBox)
        {
            if (ModelState.IsValid)
            {
                var userid = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _context.Add(mailBox);
                mailBox.DateTime=DateTime.Now;
                var user =HttpContext.User.FindFirst(ClaimTypes.Name).Value;
                mailBox.UserId = userid;
                mailBox.Sender = user;
                await _context.SaveChangesAsync();
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

            var mailBox = await _context.MailBoxes.FindAsync(id);
            if (mailBox == null)
            {
                return NotFound();
            }
            return View(mailBox);
        }

        // POST: MailBoxes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                    _context.Update(mailBox);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MailBoxExists(mailBox.Id))
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

            var mailBox = await _context.MailBoxes
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var mailBox = await _context.MailBoxes.FindAsync(id);
            _context.MailBoxes.Remove(mailBox);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MailBoxExists(int id)
        {
            return _context.MailBoxes.Any(e => e.Id == id);
        }
    }
}
