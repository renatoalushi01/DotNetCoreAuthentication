using DotNetCoreAuthentication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreAuthentication.Repository.Common
{
    public class MailBoxRepository : BaseRepository<MailBox>
    {
        private readonly DotNetCoreAuthenticationContext _context;

        public MailBoxRepository(DotNetCoreAuthenticationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<MailBox>> GetMailBoxesAsync()
        {
            return await _context.MailBoxes.Select(x => new MailBox
            {
                Sender = x.Sender,
                Receiver = x.Receiver,
                Subject = x.Subject,
                Message = x.Message,
                DateTime = x.DateTime
            }).ToListAsync();
        }
    }
}
