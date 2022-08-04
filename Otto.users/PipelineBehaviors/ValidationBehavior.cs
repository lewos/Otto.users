using FluentValidation;
using MediatR;

namespace Otto.users.PipelineBehaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        // contains every validator in mi di container for this request
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //pre
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .ToList();

            // TODO pasar a un bad request de TResponse y no una excepcion
            if (failures.Any())
                throw new ValidationException(failures);

            return next();

            //post
        }
    }
}
