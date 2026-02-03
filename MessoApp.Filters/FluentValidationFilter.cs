using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MessoApp.Filters
{
    public class FluentValidationFilter<T>(IValidator<T> validator) : IAsyncActionFilter where T : class
    {
        private readonly IValidator<T> _validator = validator;

        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var model = context.ActionArguments.Values.OfType<T>().FirstOrDefault();

            if (model == null)
            {
                await next();
                return;
            }

            var result = await _validator.ValidateAsync(model);

            if (!result.IsValid)
            {
                context.Result = new BadRequestObjectResult(result.Errors);
                return;
            }

            await next();
        }
    }
}
