using Response;
using Service.Queries.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Queries.Repository.Interface.IUsers
{
    public interface IReadUsers
    {
        public RequestResult Login(LoginDTO LoginDTO);
        public RequestResult ValidateToken(string Token);
        public RequestResult GetAllUsers();
        public RequestResult GetUsersById(Guid UserID);
        public RequestResult GetUsersByDocument(string Document);
    }
}
