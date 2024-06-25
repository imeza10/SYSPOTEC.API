using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Response;
using Service.Queries.Repository.Interface.IRoles;
using Service.Queries.Repository.Interface.IUsers;

namespace SYSPOTEC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IReadRoles _readRolesService;
        private readonly IMediator _mediator;

        public RolesController(IReadRoles readRolesService, IMediator mediator)
        {
            _readRolesService = readRolesService;
            _mediator = mediator;
        }

        /// <summary>
        /// Consulta todos los roles registrados
        /// </summary>
        /// <returns>Retorna una lista de objetos RolDTO con toda la información de los roles registrados</returns>
        /// <author>Ismael Meza Castillo</author>
        [HttpGet]
        [Route(nameof(RolesController.GetAllRoles))]
        public RequestResult GetAllRoles()
        {
            return _readRolesService.GetAllRoles();
        }

        /// <summary>
        /// Consulta un rol por su ID
        /// </summary>
        /// <returns>Retorna un objeto RolDTO con la información del Rol consultado.</returns>
        /// <author>Ismael Meza Castillo</author>
        [HttpPost]
        [Route(nameof(RolesController.GetRolByID))]
        public RequestResult GetRolByID(Guid RolID)
        {
            return _readRolesService.GetRolByID(RolID);
        }
    }
}
