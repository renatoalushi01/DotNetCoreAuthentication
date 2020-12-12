using System.Collections.Generic;
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

        public async Task DeleteAsync(int? id)
        {
            await _context.Delete(id);
        }

        public async Task<IEnumerable<MailBox>> GetAllAsync(string userId)
        {
            return await _context.GetAllAsync(userId);
        }

        public async Task<MailBox> GetMailsById(int? id)
        {
            return await _context.GetAsync(id);
        }

        public async Task UpdateMailAsync(MailBox mailBox)
        {
            await _context.UpdateAsync(mailBox);
        }
    }
}