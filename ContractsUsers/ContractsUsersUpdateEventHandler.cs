using Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Service.EventHandler.Commands;

namespace Users.Service.EventHandler
{
    partial class ContractsUsersUpdateEventHandler : INotificationHandler<ContractsUsersUpdateCommand>
    {
        private readonly ApplicationDbContext _context;
        public ContractsUsersUpdateEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ContractsUsersUpdateCommand command, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Domain.ContractsUsers
            {
                ContractID = command.ContractID,
                UserID = command.UserID,
                TypeContract = command.TypeContract,
                DateIniContract = command.DateIniContract,
                DateFinContract = command.DateFinContract,
                State = command.State,
                UrlImageSignature = command.UrlImageSignature,
                AddAt = command.AddAt
            });

            await _context.SaveChangesAsync();
        }
    }
}
