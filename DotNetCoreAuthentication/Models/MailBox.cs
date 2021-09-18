using DotNetCoreAuthentication.Repository;
using System;

namespace DotNetCoreAuthentication.Models
{
    public class MailBox : BaseEntity
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
    }
}