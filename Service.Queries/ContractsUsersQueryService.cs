using Database;
using Domain;
using Microsoft.Data.SqlClient;
using Response;
using Service.Queries.Repository.Interface.IContractsUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Queries
{
    public class ContractsUsersQueryService : IReadContractsUsers
    {
        private readonly ApplicationDbContext _context;
        public BOContractsUsers contractsObj;

        public ContractsUsersQueryService(ApplicationDbContext context)
        {
            _context = context;
            contractsObj = new(_context);
        }

        public RequestResult GetAllContractsByUserID(Guid UserID)
        {
            try
            {
                #region Validations

                if (UserID == Guid.Empty)
                    return new RequestResult { Success = false, Message = "ID de usuario invalido, intenta nuevamente." };

                #endregion

                List<ContractsUsersDTO> contractsList = contractsObj.GetAllContractsByUserID(UserID);

                if (contractsList != null && contractsList.Count() > 0)
                    return new RequestResult { Success = true, Message = "Contratos del usuario encontrados", Result = contractsList };
                else
                    return new RequestResult { Success = false, Message = "El usuario no tiene contratos." };
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
                return new RequestResult { Success = false, Message = "Se produjo un error inesperado al procesar los contratos. Por favor, contacta al soporte técnico." };
            }
            catch (Exception ex)
            {
                // Otros tipos de errores
                return new RequestResult { Success = false, Message = $"Intenta nuevamente, error: {ex.Message}" };
            }
        }
    }
}
