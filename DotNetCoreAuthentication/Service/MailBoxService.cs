using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreAuthentication.Models;
using DotNetCoreAuthentication.Repository.Common;

namespace DotNetCoreAuthentication.Service
{
    public class MailBoxService : IMailBoxService
    {
        private readonly MailBoxRepository _context;

        public MailBoxService(MailBoxRepository context)
        {
            _context = context;
        }
        public async Task AddMailAsync(MailBox mailBox)
        {
             await _context.AddAsync(mailBox);
        }
    }
}
