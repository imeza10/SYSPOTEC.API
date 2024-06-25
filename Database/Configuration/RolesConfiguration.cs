using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Configuration
{
    public class RolesConfiguration
    {
        public RolesConfiguration(EntityTypeBuilder<Roles> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(x => x.RolID);
            entityTypeBuilder.Property(x => x.Rol).IsRequired();

            var rolesList = new List<Roles>();

            rolesList.Add(new Roles
                {
                    RolID = new Guid("952d5976-edee-4324-84d9-edb861697346"),
                    Rol = "Administrador",
                    Code = "ADM",
                    State = 1,
                    AddAt = DateTime.Now
                });

            rolesList.Add(new Roles
            {
                RolID = new Guid("6f374c4b-3c62-4b47-a482-7d8c8068fd83"),
                Rol = "Cliente",
                Code = "CLI",
                State = 1,
                AddAt = DateTime.Now
            });

            entityTypeBuilder.HasData(rolesList);
        }
    }
}
