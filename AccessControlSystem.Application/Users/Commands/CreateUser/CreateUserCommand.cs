using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Domain.Entities.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Application.Users.Commands.CreateUser
{
    public record CreateUserCommand(string firstName, string lastName, string ci):ICommand<User>;
   
}
