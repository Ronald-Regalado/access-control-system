using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Application.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(Guid id):IQuery<User?>;   
}
