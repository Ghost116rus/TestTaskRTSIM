using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Aplication.CQRS.Organization.Queries.GetOrganizationList
{
    public class GetOrganizationListQuery : IRequest<List<OrganizationVM>>
    {

    }
}
