using Database;
using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BORoles
    {
        private readonly ApplicationDbContext _context;

        public BORoles(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<RolesDTO> GetAllRoles()
        {
            
            IQueryable<Roles> listRoles = _context.Roles.Where(r => r.State != 0);

            return listRoles.Select(x => new RolesDTO
            {
                RolID = x.RolID,
                Rol = x.Rol,
                State = x.State,
                Code = x.Code,
                AddAt = x.AddAt
            }).ToList();
        }

        public RolesDTO GetRolByID(Guid RolID)
        {            
            IQueryable<Roles> rol = _context.Roles.Where(r => r.RolID == RolID);

            return rol.Select(x => new RolesDTO
            {
                RolID = x.RolID,
                Rol = x.Rol,
                State = x.State,
                Code = x.Code,
                AddAt = x.AddAt
            }).FirstOrDefault();
        }
    }
}
