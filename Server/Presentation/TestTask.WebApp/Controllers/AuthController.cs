using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Aplication.CQRS.Auth.Common;
using TestTask.Aplication.CQRS.Auth.Queries.Login;

namespace TestTask.WebApp.Controllers
{
    public class AuthController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ResponseVM>> Authorize(string login, string password )
        {
            var vm = await Mediator.Send(new LoginQuery { Login = login, Password = password});

            return Ok(vm);
        }
    }
}
