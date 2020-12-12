using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCoreAuthentication.Models;

namespace DotNetCoreAuthentication.Service
{
    public interface IMailBoxService
    {
        Task AddMailAsync(MailBox mailBox);
        Task<IEnumerable<MailBox>> GetAllAsync(string userId);
        Task<MailBox> GetMailsById(int? id);
        Task UpdateMailAsync(MailBox mailBox);
        Task DeleteAsync(int? id);
    }
}