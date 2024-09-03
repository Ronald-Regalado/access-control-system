using AccessControlSystem.Application.Abstract;
using AccessControlSystem.Domain.Entities.Units;

namespace AccessControlSystem.Application.Units.Queries.GetUnitById
{
    public record GetUnitByIdQuery(Guid Id) : IQuery<Unit?>;

}
