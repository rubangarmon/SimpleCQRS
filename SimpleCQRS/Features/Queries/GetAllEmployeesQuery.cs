using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCQRS.Context;
using SimpleCQRS.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCQRS.Features.Queries
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<Employee>>
    {
        public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
        {

            private readonly IAppContext _context;
            public GetAllEmployeesQueryHandler(IAppContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
            {
                var employeesList = await _context.employees.ToListAsync();
                if(employeesList == null)
                {
                    return null;
                }
                return employeesList.AsReadOnly();
            }
        }
    }
}
