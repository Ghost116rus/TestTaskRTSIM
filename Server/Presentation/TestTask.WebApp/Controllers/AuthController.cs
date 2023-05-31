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
        [HttpPost]
        public async Task<ActionResult<ResponseVM>> Authorize([FromBody] LoginQuery request )
        {
            var vm = await Mediator.Send(request);

            return Ok(vm);
        }
    }
}
