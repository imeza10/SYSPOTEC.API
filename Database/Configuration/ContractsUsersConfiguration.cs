using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Database.Configuration
{
    public class ContractsUsersConfiguration
    {
        public ContractsUsersConfiguration(EntityTypeBuilder<ContractsUsers> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(x => x.ContractID);
            entityTypeBuilder.Property(x => x.UserID).IsRequired();

            // Configurar la relación con Users
            entityTypeBuilder.HasOne(cu => cu.User)
                             .WithMany(u => u.ContractsUsers)
                             .HasForeignKey(cu => cu.UserID);
        }
    }
}
