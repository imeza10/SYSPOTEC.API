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
    public class RolesUpdateEventHandler :  IRequestHandler<RolesUpdateCommand, RequestResult>
    {
        private readonly ApplicationDbContext _context;
        public RolesUpdateEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RequestResult> Handle(RolesUpdateCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var rolBD = _context.Roles.FirstOrDefault(x => x.RolID == command.RolID) ?? null;

                if (rolBD == null)
                    return new RequestResult { Success = false, Message = "El ID del rol no existe o no es valido." };

                var rol = new Roles
                {
                    RolID = command.RolID,
                    Rol = command.Rol,
                    Code = command.Code,
                    State = command.State,
                    AddAt = DateTime.Now
                };

                _context.Roles.Update(rol);
                await _context.SaveChangesAsync(cancellationToken);

                var rolDTO = new RolesDTO
                {
                    RolID = rol.RolID,
                    Rol = rol.Rol,
                    Code = rol.Code,
                    State = rol.State,
                    AddAt = DateTime.Now
                };

                return new RequestResult { Success = true, Message = "Rol actualizado exitosamente.", Result = rolDTO };
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
