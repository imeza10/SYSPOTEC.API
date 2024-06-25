using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Response;
using Service.Queries.Repository.Interface.IContractsUsers;
using Service.Queries.Repository.Interface.IRoles;

namespace SYSPOTEC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsUsersController : ControllerBase
    {
        private readonly IReadContractsUsers _readContractsUsersService;
        private readonly IMediator _mediator;

        public ContractsUsersController(IReadContractsUsers readContractsUsersService, IMediator mediator)
        {
            _readContractsUsersService = readContractsUsersService;
            _mediator = mediator;
        }

        /// <summary>
        /// Consulta todos los contratos registrados
        /// </summary>
        /// <returns>Retorna una lista de objetos ContractsUsersDTO con la información de los contratos del usuario.</returns>
        /// <author>Ismael Meza Castillo</author>
        [HttpGet]
        [Route(nameof(ContractsUsersController.GetAllContractsByUserID))]
        public RequestResult GetAllContractsByUserID(Guid UserID)
        {
            return _readContractsUsersService.GetAllContractsByUserID(UserID);
        }

    }
}
