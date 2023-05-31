using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Aplication.Interfaces;

namespace TestTask.Aplication.CQRS.Organizations.Queries.GetOrganizationList
{
    public class GetOrganizationListQueryHandler : IRequestHandler<GetOrganizationListQuery, List<OrganizationVM>>
    {
        private readonly ITestTaskDbContext _context;
        private readonly IMapper _mapper;

        public GetOrganizationListQueryHandler(ITestTaskDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OrganizationVM>> Handle(GetOrganizationListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Organizations.ProjectTo<OrganizationVM>(_mapper.ConfigurationProvider).ToListAsync();
            return result;
        }
    }
}
