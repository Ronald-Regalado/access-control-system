using AccessControlSystem.Application.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControlSystem.Application.Units.Queries.GetAllUnits
{
    public record GetAllUnitsQuery(): IQuery<IEnumerable<Unit>>;
}
