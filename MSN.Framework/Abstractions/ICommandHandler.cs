using MediatR;

namespace MSN.Framework.Abstractions;

public interface ICommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult>
where TCommand : ICommand<TResult>;