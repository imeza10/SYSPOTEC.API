using Database;
using Domain;
using MediatR;
using Microsoft.Data.SqlClient;
using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Service.EventHandler.Commands;

namespace Users.Service.EventHandler
{
    public class RolesCreateEventHandler : IRequestHandler<RolesCreateCommand, RequestResult>
    {
        private readonly ApplicationDbContext _context;
        public RolesCreateEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RequestResult> Handle(RolesCreateCommand command, CancellationToken cancellationToken)
        {
            try
            {

                #region Validations

                var rol = _context.Roles.Where(r => r.Code == command.Code).FirstOrDefault();

                if (rol != null)
                    return new RequestResult { Success = false, Message = "Ya existe un rol con este codigo: " + command.Code };
                
                #endregion

                var rolBD = new Roles
                {
                    RolID = command.RolID,
                    Rol = command.Rol,
                    Code = command.Code,
                    State = command.State,
                    AddAt = DateTime.Now
                };

                await _context.AddAsync(rolBD);
                await _context.SaveChangesAsync(cancellationToken);

                var rolDTO = new RolesDTO
                {
                    RolID = rolBD.RolID,
                    Rol = rolBD.Rol,
                    State = rolBD.State,
                    Code = rolBD.Code,
                    AddAt = DateTime.Now
                };

                return new RequestResult { Success = true, Message = "Rol creado exitosamente.", Result = rolDTO };
            }
            catch (SqlException ex) when (ex.Number == -1)
            {
                // Error de conexión a la base de datos
                return new RequestResult { Success = false, Message = "Error de conexión a la base de datos. Por favor, verifica tu conexión y vuelve a intentarlo." };
            }
            catch (SqlException ex)
            {
                // Otros errores relacionados con SQL
                return new RequestResult { Success = false, Message = $"Error de base de datos: {ex.Message}" };
            }
            catch (NullReferenceException)
            {
                // Error de referencia nula
                return new RequestResult { Success = false, Message = "Se produjo un error inesperado al procesar la información. Por favor, contacta al soporte técnico." };
            }
            catch (Exception ex)
            {
                // Otros tipos de errores
                return new RequestResult { Success = false, Message = $"Intenta nuevamente, error: {ex.Message}" };
            }
            
        }
    }
}
