using Database;
using Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BOUsers
    {
        private readonly ApplicationDbContext _context;

        public BOUsers(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UsersDTO> GetAllUsers()
        {
            //Preparamos la consulta con un Iqueryable para dejarla lo mas plana posible...
            IQueryable<Users> listUsers = _context.Users.Where(u => u.State != 0);

            //Hacemos select de los datos que vamos a retornar y traemos la data a memoria con el ToList()
            listUsers.Select(x => new Users
            {
                UserID = x.UserID,
                Document = x.Document,
                Name = x.Name,
                Lastname = x.Lastname,
                State = x.State,
                Address = x.Address,
                Email = x.Email,
                Phone = x.Phone,
                Password = x.Password,
                RolID = x.RolID,
                AddAt = x.AddAt
            }).ToList();

            //Cuando tenemos la consulta en memoria, hacemos post procesamiento de los datos según la necesidad.
            return listUsers.Select(x => new UsersDTO
            {
                UserID = x.UserID,
                Document = x.Document,
                Name = x.Name,
                Lastname = x.Lastname,
                State = x.State == 1 ? "Activo" : "Inactivo",
                Address = x.Address,
                Email = x.Email,
                Phone = x.Phone,
                Password = x.Password,
                RolID = x.RolID,
                Rol = x.RolesNavigation != null ? x.RolesNavigation.Rol : "",
                AddAt = x.AddAt
            }).ToList();
        }

        public UsersDTO GetUserByID(Guid UserID)
        {
            //Preparamos la consulta con un Iqueryable para dejarla lo mas plana posible...
            IQueryable<Users> users = _context.Users.Where(u => u.UserID == UserID && u.State != 0);

            //Hacemos select de los datos que vamos a retornar y traemos la data a memoria con el ToList()
            users.Select(x => new Users
            {
                UserID = x.UserID,
                Document = x.Document,
                Name = x.Name,
                Lastname = x.Lastname,
                State = x.State,
                Address = x.Address,
                Email = x.Email,
                Phone = x.Phone,
                Password = x.Password,
                RolID = x.RolID,
                AddAt = x.AddAt
            }).FirstOrDefault();

            //Cuando tenemos la consulta en memoria, hacemos post procesamiento de los datos según la necesidad.
            return users.Select(x => new UsersDTO
            {
                UserID = x.UserID,
                Document = x.Document,
                Name = x.Name,
                Lastname = x.Lastname,
                State = x.State == 1 ? "Activo" : "Inactivo",
                Address = x.Address,
                Email = x.Email,
                Phone = x.Phone,
                Password = x.Password,
                RolID = x.RolID,
                Rol = x.RolesNavigation != null ? x.RolesNavigation.Rol : "",
                AddAt = x.AddAt
            }).FirstOrDefault();
        }

        public UsersDTO GetUserByDocument(string Document)
        {
            //Preparamos la consulta con un Iqueryable para dejarla lo mas plana posible...
            IQueryable<Users> users = _context.Users.Where(u => u.Document == Document && u.State != 0);

            //Hacemos select de los datos que vamos a retornar y traemos la data a memoria con el ToList()
            users.Select(x => new Users
            {
                UserID = x.UserID,
                Document = x.Document,
                Name = x.Name,
                Lastname = x.Lastname,
                State = x.State,
                Address = x.Address,
                Email = x.Email,
                Phone = x.Phone,
                Password = x.Password,
                RolID = x.RolID,
                AddAt = x.AddAt
            }).FirstOrDefault();

            //Cuando tenemos la consulta en memoria, hacemos post procesamiento de los datos según la necesidad.
            return users.Select(x => new UsersDTO
            {
                UserID = x.UserID,
                Document = x.Document,
                Name = x.Name,
                Lastname = x.Lastname,
                State = x.State == 1 ? "Activo" : "Inactivo",
                Address = x.Address,
                Email = x.Email,
                Phone = x.Phone,
                Password = x.Password,
                RolID = x.RolID,
                Rol = x.RolesNavigation != null ? x.RolesNavigation.Rol : "",
                AddAt = x.AddAt
            }).FirstOrDefault();
        }
    }
}
