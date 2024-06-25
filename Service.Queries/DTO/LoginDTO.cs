using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Queries.DTO
{
    public class LoginDTO
    {
        public required string Document { get; set; }
        public required string Password { get; set; }
    }
}
