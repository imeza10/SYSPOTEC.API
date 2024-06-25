using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Database.Configuration
{
    public class UsersConfiguration
    {
        public UsersConfiguration(EntityTypeBuilder<Users> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(x => x.UserID);
            entityTypeBuilder.Property(x => x.Document).IsRequired();
            entityTypeBuilder.Property(x => x.Name).IsRequired();
            entityTypeBuilder.Property(x => x.Lastname).IsRequired();
            entityTypeBuilder.Property(x => x.Password).IsRequired();

            // Configuracion de la relacion Users y Roles
            entityTypeBuilder.HasOne(x => x.RolesNavigation)
                             .WithMany(r => r.Users)
                             .HasForeignKey(x => x.RolID);

            // Configurar la relación con ContractsUsers
            entityTypeBuilder.HasMany(x => x.ContractsUsers)
                             .WithOne(cu => cu.User)
                             .HasForeignKey(cu => cu.UserID);

            var RolID = new Guid("952d5976-edee-4324-84d9-edb861697346");
            var userList = new List<Users>();
            var random = new Random();

            userList.Add(new Users
            {
                UserID = Guid.NewGuid(),
                Document = "12345",
                Name = "Admin",
                Lastname = "System",
                Address = "St 56 Av 21",
                Email = "admin@gmail.com",
                Phone = "300 123 4567",
                Password = ComputeSha1AndMd5("8xYqX0Pg"),
                State = 1,
                UrlPicProfile = "",
                UrlImageSignature = "",
                RolID = RolID,
                AddAt = DateTime.Now
            });

            entityTypeBuilder.HasData(userList);
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
