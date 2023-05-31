using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Aplication.CQRS.Auth.Common;

namespace TestTask.Aplication.CQRS.Auth.Commands.Registration
{
    public class RegistrationCommand : IRequest<ResponseVM>
    {
        public int OrganizationId { get; set; }
        public string Name { get; set; }    
        public string Login { get; set; }    
        public string Password { get; set; }    
    }
}
