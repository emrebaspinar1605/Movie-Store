using FluentValidation;


namespace WebApi.Application.CustomerOperations.Queries.Validators
{
    public class GetCustomerQueryDetailValidator : AbstractValidator<GetCustomerQueryDetail>
    {
        public GetCustomerQueryDetailValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}