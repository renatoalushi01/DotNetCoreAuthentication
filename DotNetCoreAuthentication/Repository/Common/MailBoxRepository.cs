using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreAuthentication.Models;

namespace DotNetCoreAuthentication.Repository.Common
{
    public class MailBoxRepository : BaseRepository<MailBox>
    {
        private readonly DotNetCoreAuthenticationContext _context;

        public MailBoxRepository(DotNetCoreAuthenticationContext context) : base(context)
        {
            _context = context;
        }
    }
}
