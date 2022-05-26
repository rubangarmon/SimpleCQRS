using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCQRS.Context;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCQRS.Features.Commands
{
    public class UpdateEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }

        public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, int>
        {
            private readonly IAppContext _appContext;
            public UpdateEmployeeCommandHandler(IAppContext appContext)
            {
                _appContext = appContext;
            }

            public async Task<int> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var emp = _appContext.employees.
                    Where(e => e.Id == request.Id)
                    .FirstOrDefault();
                if (emp == null)
                {
                    return default;
                }
                else
                {
                    emp.Name = request.Name;
                    emp.Address = request.Address;
                    emp.Country = request.Country;
                    int id = await _appContext.SaveChangesAsync();
                    return id;
                }



            }
        }
    }
}
