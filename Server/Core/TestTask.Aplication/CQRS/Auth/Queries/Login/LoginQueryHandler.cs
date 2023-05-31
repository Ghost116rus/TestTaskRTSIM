using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TestTask.Aplication.Common.Exceptions;
using TestTask.Aplication.CQRS.Auth.Common;
using TestTask.Aplication.Interfaces;

namespace TestTask.Aplication.CQRS.Auth.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ResponseVM>
    {
        private readonly ITestTaskDbContext _context;
        
        public LoginQueryHandler(ITestTaskDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseVM> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == request.Login && u.Password == request.Password);

            if (user is null)
            {
                throw new NotFoundException(request.Login, request.Password);
            }

            return new ResponseVM { Success = true };
        }
    }
}
