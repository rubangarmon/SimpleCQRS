using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCQRS.Context;
using SimpleCQRS.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCQRS.Features.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int Id { get; set; }

        public class GetEmployeeByIdQueryHandler: IRequestHandler<GetEmployeeByIdQuery, Employee>
        {
            private readonly IAppContext appContext;

            public GetEmployeeByIdQueryHandler(IAppContext appContext)
            {
                this.appContext = appContext;
            }

            public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
            {
                var employee = await appContext.employees.Where(emp => emp.Id == request.Id).FirstOrDefaultAsync();
                if (employee == null) return null;
                return employee;
            }
        }
    }
}
