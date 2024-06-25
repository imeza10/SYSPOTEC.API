using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Service.EventHandler.Commands
{
    public class ContractsUsersUpdateCommand : INotification
    {
        public Guid ContractID { get; set; }
        public Guid UserID { get; set; }
        public Guid TypeContract { get; set; }
        public string? UrlImageSignature { get; set; }
        public required int State { get; set; }
        public DateTime DateIniContract { get; set; }
        public DateTime DateFinContract { get; set; }
        public DateTime AddAt { get; set; }
    }
}
