using MediatR;

namespace AireSpring.Application.Common;

public interface IQueryBase<TResponse> : IRequest<TResponse>, IBaseRequest where TResponse : class
{
}
