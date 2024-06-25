using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Queries.Repository.Interface.IContractsUsers
{
    public interface IReadContractsUsers
    {
        public RequestResult GetAllContractsByUserID(Guid UserID);
    }
}
