using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Aplication.CQRS.Organizations.Queries.GetOrganizationLogins
{
    public class GetOrganizationLoginsQuery : IRequest<List<string>>
    {
        public int Id { get; set; }
    }
}
