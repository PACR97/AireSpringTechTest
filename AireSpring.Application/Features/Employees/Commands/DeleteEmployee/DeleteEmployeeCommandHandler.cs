using AireSpring.Application.Contracts;
using AireSpring.Application.Exceptions;
using MediatR;

namespace AireSpring.Application.Features.Employees.Commands.DeleteEmployee;

/// <summary>
/// Implementation of the command <see cref="DeleteEmployeeCommand"/>
/// </summary>
public sealed class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly IEmployeeRepository repo;

    public DeleteEmployeeCommandHandler(IEmployeeRepository repo)
    {
        this.repo = repo;
    }

    public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var result = await repo.DeleteAsync(request.Id);
        if (result == 0)
            throw new BadRequestException($"The employee with id {request.Id} could not be deleted");
        return Unit.Value;
    }
}
