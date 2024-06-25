using Database;
using Domain;
using Microsoft.Data.SqlClient;
using Response;
using Service.Queries.Repository.Interface.IRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Queries
{
    public class RolesQueryService: IReadRoles
    {
        private readonly ApplicationDbContext _context;
        public BORoles rolesObj;

        public RolesQueryService(ApplicationDbContext context)
        {
            _context = context;
            rolesObj = new(_context);
        }

        public RequestResult GetAllRoles()
        {
            try
            {
                List<RolesDTO> usersList = rolesObj.GetAllRoles();

                if (usersList != null && usersList.Count() > 0)
                    return new RequestResult { Success = true, Message = "Roles encontrados", Result = usersList };
                else
                    return new RequestResult { Success = false, Message = "No hay roles registrados." };
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
                return new RequestResult { Success = false, Message = "Se produjo un error inesperado al procesar los roles. Por favor, contacta al soporte técnico." };
            }
            catch (Exception ex)
            {
                // Otros tipos de errores
                return new RequestResult { Success = false, Message = $"Intenta nuevamente, error: {ex.Message}" };
            }
        }

        public RequestResult GetRolByID(Guid RolID)
        {
            try
            {
                #region Validations

                #endregion

                RolesDTO user = rolesObj.GetRolByID(RolID);

                if (user != null)
                    return new RequestResult { Success = true, Message = "Roles encontrados", Result = user };
                else
                    return new RequestResult { Success = false, Message = "No hay roles registrados." };
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
                return new RequestResult { Success = false, Message = "Se produjo un error inesperado al procesar el rol. Por favor, contacta al soporte técnico." };
            }
            catch (Exception ex)
            {
                // Otros tipos de errores
                return new RequestResult { Success = false, Message = $"Intenta nuevamente, error: {ex.Message}" };
            }
        }
    }
}
