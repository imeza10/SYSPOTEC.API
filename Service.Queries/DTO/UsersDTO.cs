using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UsersDTO
    {
        public Guid UserID { get; set; }
        public string? Document { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? UrlPicProfile { get; set; }
        public string? UrlImageSignature { get; set; }
        public Guid RolID { get; set; }
        public string? Rol { get; set; }
        public string? State { get; set; }
        public DateTime? AddAt { get; set; }
    }
}
