using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Users
    {
        public Guid UserID { get; set; }
        public required string Document { get; set; }
        public required string Name { get; set; }
        public required string Lastname { get; set; }
        public required string Address { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Password { get; set; }
        public string ?UrlPicProfile { get; set; }
        public string? UrlImageSignature { get; set; }
        public Guid RolID { get; set; }
        public int? State { get; set; }
        public DateTime? AddAt { get; set; }
        // Propiedad de navegación
        public Roles? RolesNavigation { get; set; }
        // Propiedad de navegación para la relación con ContractsUsers
        public ICollection<ContractsUsers>? ContractsUsers { get; set; }
    }
}
