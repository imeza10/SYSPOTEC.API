using Domain;
using MediatR;
using Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Service.EventHandler.Commands
{
    public class UsersCreateCommand : IRequest<RequestResult>
    {
        public required string Document { get; set; }
        public required string Name { get; set; }
        public required string Lastname { get; set; }
        public required string Address { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Password { get; set; }
        public string? UrlPicProfile { get; set; }
        public string? UrlImageSignature { get; set; }
        public Guid RolID { get; set; }
        public int? State { get; set; }
        public bool IsAdmin { get; set; } = false;
        public DateTime? AddAt { get; set; }
    }
}
