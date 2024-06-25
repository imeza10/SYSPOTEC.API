using Database;
using Domain;
using MediatR;
using Microsoft.Data.SqlClient;
using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Users.Service.EventHandler.Commands;

namespace Users.Service.EventHandler
{
    public class UsersUpdateEventHandler : IRequestHandler<UsersUpdateCommand, RequestResult>
    {
        private readonly ApplicationDbContext _context;
        public UsersUpdateEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RequestResult> Handle(UsersUpdateCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var users = _context.Users.FirstOrDefault(x => x.UserID == command.UserID) ?? null;

                if (users == null)
                    return new RequestResult { Success = false, Message = "Usuario no encontrado, revise e intente nuevamente." };

                var code = (command.IsAdmin ? "ADM" : "CLI");
                var rol = _context.Roles.Where(r => r.Code == code).FirstOrDefault();

                users.UserID = command.UserID;
                users.Name = command.Name;
                users.Lastname = command.Lastname;
                users.Address = command.Address;
                users.Email = command.Email;
                users.Phone = command.Phone;
                users.Password = ComputeSha1AndMd5(command.Password);
                users.UrlPicProfile = command.UrlPicProfile;
                users.UrlImageSignature = command.UrlImageSignature;
                users.RolID = rol.RolID;
                users.State = command.State;

                _context.Users.Update(users);
                await _context.SaveChangesAsync(cancellationToken);

                var userDTO = new UsersDTO
                {
                    UserID = users.UserID,
                    Document = users.Document,
                    Name = users.Name,
                    Lastname = users.Lastname,
                    Address = users.Address,
                    Email = users.Email,
                    Phone = users.Phone,
                    Password = users.Password,
                    UrlPicProfile = users.UrlPicProfile,
                    UrlImageSignature = users.UrlImageSignature,
                    RolID = rol.RolID,
                    Rol = rol.Rol,
                    AddAt = users.AddAt
                };

                return new RequestResult { Success = true, Message = "Usuario actualizado exitosamente.", Result = userDTO };
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

        public static string ComputeSha1(string input)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha1.ComputeHash(inputBytes);
                return Convert.ToHexString(hashBytes).ToLower();
            }
        }

        public static string ComputeMd5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return Convert.ToHexString(hashBytes).ToLower();
            }
        }

        public static string ComputeSha1AndMd5(string input)
        {
            string sha1Hash = ComputeSha1(input);
            return ComputeMd5(sha1Hash);
        }
    }
}
