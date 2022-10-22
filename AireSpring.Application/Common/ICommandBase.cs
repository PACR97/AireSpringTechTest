using MediatR;

namespace AireSpring.Application.Common;

public interface ICommandBase : IRequest, IBaseRequest
{
}

public interface ICommandBase<TResponse> : IRequest<TResponse>, IBaseRequest where TResponse : class
{
}
