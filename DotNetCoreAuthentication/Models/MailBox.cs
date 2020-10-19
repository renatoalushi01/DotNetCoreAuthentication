using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreAuthentication.Data;

namespace DotNetCoreAuthentication.Models
{
    public class MailBox
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUsers { get; set; }
        }
}
