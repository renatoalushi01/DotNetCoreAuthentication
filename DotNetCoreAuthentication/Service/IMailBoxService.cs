using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreAuthentication.Models;

namespace DotNetCoreAuthentication.Service
{
    public interface IMailBoxService
    {
        Task AddMailAsync(MailBox mailBox);
    }
}
