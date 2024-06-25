using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RolesDTO
    {
        public Guid RolID { get; set; }
        public required string Rol { get; set; }
        public required string Code { get; set; }
        public required int State { get; set; }
        public DateTime? AddAt { get; set; }
    }
}
