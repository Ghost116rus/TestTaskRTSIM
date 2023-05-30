using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Aplication.Interfaces;

namespace TestTask.Aplication.CQRS.Organization.Queries.GetOrganizationList
{
    public class GetOrganizationListQueryHandler : IRequestHandler<GetOrganizationListQuery, List<OrganizationVM>>
    {
        private readonly ITestTaskDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrganizationListQueryHandler(ITestTaskDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<OrganizationVM>> Handle(GetOrganizationListQuery request, CancellationToken cancellationToken)
        {
            var a = 5 + 5;
            return null;
        }
    }
}
