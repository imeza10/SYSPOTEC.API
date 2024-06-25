using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Queries.Repository.Interface.IRoles
{
    public interface IReadRoles
    {
        public RequestResult GetAllRoles();
        public RequestResult GetRolByID(Guid RolID);
    }
}
