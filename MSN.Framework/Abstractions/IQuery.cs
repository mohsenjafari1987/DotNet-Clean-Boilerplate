using MediatR;

namespace MSN.Framework.Abstractions;

public interface IQuery<out TResult> : IRequest<TResult>;