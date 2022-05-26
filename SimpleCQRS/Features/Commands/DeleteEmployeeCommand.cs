using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCQRS.Context;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCQRS.Features.Commands
{
    public class DeleteEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, int>
        {
            private readonly IAppContext _appContext;
            public DeleteEmployeeCommandHandler(IAppContext appContext)
            {
                _appContext = appContext;
            }
            public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                var emp = await _appContext.employees.Where(e => e.Id == request.Id).FirstOrDefaultAsync();
                if (emp == null) return default;
                _appContext.employees.Remove(emp);
                int flag = await _appContext.SaveChangesAsync();
                return flag;

            }
        }
    }
}
