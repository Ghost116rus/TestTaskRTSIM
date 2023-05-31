using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Aplication.CQRS.Organizations.Queries.GetOrganizationList;
using TestTask.Aplication.CQRS.Organizations.Queries.GetOrganizationLogins;

namespace TestTask.WebApp.Controllers
{
    public class OrganizationController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetOrganizationsList()
        {
            var vm = await Mediator.Send(new GetOrganizationListQuery());
            return Ok(vm);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrganizationLogins(int organizationId)
        {
            var vm = await Mediator.Send(new GetOrganizationLoginsQuery { Id = organizationId});
            return Ok(vm);
        }
    }
}
