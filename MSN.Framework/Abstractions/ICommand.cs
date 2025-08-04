using MediatR;

namespace MSN.Framework.Abstractions;

public interface ICommand<out TResult> : IRequest<TResult>; 