using Database;
using Domain;
using MediatR;
using Microsoft.Data.SqlClient;
using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Users.Service.EventHandler.Commands;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Users.Service.EventHandler
{
    public class UsersCreateEventHandler : IRequestHandler<UsersCreateCommand, RequestResult>
    {
        private readonly ApplicationDbContext _context;
        public UsersCreateEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RequestResult> Handle(UsersCreateCommand command, CancellationToken cancellationToken)
        {
            #region Validations
            
            var code = (command.IsAdmin ? "ADM" : "CLI");
            var rol = _context.Roles.Where(r => r.Code == code).FirstOrDefault();

            if (rol == null)
            {
                return new RequestResult { Success = false, Message = "Rol no encontrado." };
            }

            var userBD = _context.Users.Where(u => u.Document == command.Document).FirstOrDefault();

            if(userBD != null)
                return new RequestResult { Success = false, Message = "Ya existe un usuario con ese numero de documento." };

            #endregion

            try
            {
                var user = new Domain.Users
                {
                    UserID = Guid.NewGuid(),
                    Document = command.Document,
                    Name = command.Name,
                    Lastname = command.Lastname,
                    Address = command.Address,
                    Email = command.Email,
                    Phone = command.Phone,
                    Password = ComputeSha1AndMd5(command.Password),
                    UrlPicProfile = command.UrlPicProfile,
                    UrlImageSignature = command.UrlImageSignature,
                    RolID = rol.RolID,
                    State = 1,
                    AddAt = DateTime.Now
                };

                await _context.AddAsync(user);
                await _context.SaveChangesAsync(cancellationToken);

                return new RequestResult { Success = true, Message = "Usuario creado exitosamente.", Result = user };
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
