using DotNetCoreAuthentication.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreAuthentication.Repository
{
    public class BaseEntity
    {
        
        [Key]
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser Application { get; set; }
    }
}