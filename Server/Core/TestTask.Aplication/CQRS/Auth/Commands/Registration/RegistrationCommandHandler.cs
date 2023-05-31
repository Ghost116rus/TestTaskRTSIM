using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Aplication.CQRS.Auth.Common;
using TestTask.Aplication.Interfaces;
using TestTask.Domain;

namespace TestTask.Aplication.CQRS.Auth.Commands.Registration
{
    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, ResponseVM>
    {
        private readonly ITestTaskDbContext _context;

        public RegistrationCommandHandler(ITestTaskDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseVM> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            var organization = await _context.Organizations.FirstOrDefaultAsync(x => x.Id == request.OrganizationId);

            if (organization is null)
            {
                return new ResponseVM { UserId = -1, Success = false, Message = "Такой организации не существует" };
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Login == request.Login && x.OrganizationId == request.OrganizationId);

            if (user is not null)
            {
                return new ResponseVM { UserId = -1, Success = false, Message = "Такой логин у организации уже существует!" };
            }

            user = new User { Login = request.Login, Name = request.Name, OrganizationId = request.OrganizationId, Password = request.Password };

            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseVM { UserId = user.Id, Success = true, Message = "Успешная регистрация!" };

        }

    }
}
