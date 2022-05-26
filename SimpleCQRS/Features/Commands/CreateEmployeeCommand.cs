using MediatR;
using SimpleCQRS.Context;
using SimpleCQRS.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCQRS.Features.Commands
{
    public class CreateEmployeeCommand : IRequest<int> 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Addreess { get; set; }
        public string Country { get; set; }

        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
        {
            private readonly IAppContext _context;
            public CreateEmployeeCommandHandler(IAppContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = new Employee();
                employee.Name = request.Name;
                employee.Address = request.Addreess;
                employee.Country = request.Addreess;
                _context.employees.Add(employee);
                int id = await _context.SaveChangesAsync();
                return id;
            }
        }
    }
}
