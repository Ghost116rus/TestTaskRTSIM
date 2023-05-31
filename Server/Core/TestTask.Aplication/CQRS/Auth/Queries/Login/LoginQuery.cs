using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Aplication.CQRS.Auth.Common;

namespace TestTask.Aplication.CQRS.Auth.Queries.Login
{
    public class LoginQuery : IRequest <ResponseVM>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
