using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Aplication.CQRS.Organization.Queries.GetOrganizationList;

namespace TestTask.WebApp.Controllers
{
    public class OrganizationController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetOrganizationsList()
        {
            var vm = Mediator.Send(new GetOrganizationListQuery());
            return Ok("");
        }
    }
}
