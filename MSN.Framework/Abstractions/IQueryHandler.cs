using MediatR;

namespace MSN.Framework.Abstractions;

public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult>
where TQuery : IQuery<TResult>;