using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Response;
using Service.Queries.DTO;
using Service.Queries.Repository.Interface.IUsers;
using Users.Service.EventHandler.Commands;

namespace SYSPOTEC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IReadUsers _readUsersService;
        private readonly IMediator _mediator;
        private IConfiguration _configuration;

        public UsersController(IReadUsers readUsersService, IMediator mediator, IConfiguration configuration)
        {
            _readUsersService = readUsersService;
            _mediator = mediator;
            _configuration = configuration;
        }

        /// <summary>
        /// Crea una sesión de usuario
        /// </summary>
        /// <returns>Retorna un true o false si el inicio de sesión fue exitoso o no.</returns>
        /// <author>Ismael Meza Castillo</author>
        [HttpPost]
        [Route(nameof(UsersController.Login))]
        public RequestResult Login(LoginDTO LoginDTO)
        {
            return _readUsersService.Login(LoginDTO);
        }

        /// <summary>
        /// Valida el token
        /// </summary>
        /// <returns>Retorna un true o false si el inicio de sesión fue exitoso o no.</returns>
        /// <author>Ismael Meza Castillo</author>
        [HttpPost]
        [Route(nameof(UsersController.ValidateToken))]
        public RequestResult ValidateToken(string Token)
        {
            return _readUsersService.ValidateToken(Token);
        }

        /// <summary>
        /// Consulta todos los usuarios registrados
        /// </summary>
        /// <returns>Retorna una lista de objetos de la clase UsersDTO, con todos los datos de los usuarios</returns>
        /// <author>Ismael Meza Castillo</author>
        [HttpGet]
        [Route(nameof(UsersController.GetAllUsers))]
        public RequestResult GetAllUsers()
        {
            return _readUsersService.GetAllUsers();
        }

        /// <summary>
        /// Consulta un usuario registrado por su ID
        /// </summary>
        /// <returns>Retorna un objeto de la clase UsersDTO, con todos los datos del usuario</returns>
        /// <author>Ismael Meza Castillo</author>
        [HttpPost]
        [Route(nameof(UsersController.GetUsersById))]
        public RequestResult GetUsersById([FromForm] Guid UserID)
        {
            return _readUsersService.GetUsersById(UserID);
        }

        /// <summary>
        /// Consulta un usuario registrado por su Documento
        /// </summary>
        /// <returns>Retorna un objeto de la clase UsersDTO, con todos los datos del usuario</returns>
        /// <author>Ismael Meza Castillo</author>
        [HttpPost]
        [Route(nameof(UsersController.GetUsersByDocument))]
        public RequestResult GetUsersByDocument(string Document)
        {
            return _readUsersService.GetUsersByDocument(Document);
        }

        /// <summary>
        /// Crea un usuario nuevo asignandole un ID nuevo
        /// </summary>
        /// <param name="command">Este objeto contiene la información del usuario a crear.</param>
        /// <returns>Resultado de la petición.</returns>
        /// <author>Ismael Meza Castillo</author>
        [HttpPost]
        [Route(nameof(UsersController.CreateUser))]
        public async Task<RequestResult> CreateUser([FromBody] UsersCreateCommand command)
        {
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Actualiza un usuario según su ID
        /// </summary>
        /// <param name="command">Este objeto contiene la información del usuario a actualizar.</param>
        /// <returns>Resultado de la petición.</returns>
        /// <author>Ismael Meza Castillo</author>
        [HttpPost]
        [Route(nameof(UsersController.UpdateUsers))]
        public async Task<RequestResult> UpdateUsers(UsersUpdateCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
