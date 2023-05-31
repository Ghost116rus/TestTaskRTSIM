using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Aplication.Common.Exceptions;
using TestTask.Aplication.Interfaces;
using TestTask.Domain;

namespace TestTask.Aplication.CQRS.Organizations.Queries.GetOrganizationLogins
{
    public class GetOrganizationLoginsQueryHandler : IRequestHandler<GetOrganizationLoginsQuery, List<string>>
    {
        private readonly ITestTaskDbContext _context;

        public GetOrganizationLoginsQueryHandler(ITestTaskDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> Handle(GetOrganizationLoginsQuery request, CancellationToken cancellationToken)
        {
            var organization = await _context.Organizations.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (organization is null)
            {
                throw new NotFoundException("Organization", request.Id);
            }

            var users = await _context.Users.Where(u => u.OrganizationId == request.Id).ToListAsync();

            if (users.Count == 0)
            {
                return null;
            }
            else
            {
                var list = new List<string>();
                foreach (var user in users)
                {
                    list.Add(user.Login);
                }
                return list;
            }
        }
    }
}
