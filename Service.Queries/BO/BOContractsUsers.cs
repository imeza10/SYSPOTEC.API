using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BOContractsUsers
    {
        private readonly ApplicationDbContext _context;

        public BOContractsUsers(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ContractsUsersDTO> GetAllContractsByUserID(Guid UserID)
        {
            //Preparamos la consulta con un Iqueryable para dejarla lo mas plana posible...
            IQueryable<ContractsUsers> listContracts = _context.ContractsUsers.Where(c => c.UserID == UserID);

            //Hacemos select de los datos que vamos a retornar y traemos la data a memoria con el ToList()
            listContracts.Select(x => new ContractsUsers
            {
                ContractID = x.ContractID,
                UserID = x.UserID,
                TypeContract = x.TypeContract,
                DateIniContract = x.DateIniContract,
                DateFinContract = x.DateFinContract,
                UrlImageSignature = x.UrlImageSignature,
                State = x.State,
                AddAt = x.AddAt
            }).ToList();

            //Cuando tenemos la consulta en memoria, hacemos post procesamiento de los datos según la necesidad.
            return listContracts.Select(x => new ContractsUsersDTO
            {
                ContractID = x.ContractID,
                UserID = x.UserID,
                TypeContract = x.TypeContract,
                DateIniContract = x.DateIniContract,
                DateFinContract = x.DateFinContract,
                UrlImageSignature = x.UrlImageSignature,
                State = x.State,
                AddAt = x.AddAt
            }).ToList();
        }
    }
}
