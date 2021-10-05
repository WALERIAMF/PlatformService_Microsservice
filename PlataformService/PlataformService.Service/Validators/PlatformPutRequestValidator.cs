using FluentValidation;
using PlataformService.Domain.Request;

namespace PlataformService.Service.Validators

{
    public class PlatformPutRequestValidator : AbstractValidator<PlatformPutRequest>
    {
        public PlatformPutRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("É necessário informar o Nome.")
                .MinimumLength(3).WithMessage("Informar um nome maior")
                .MaximumLength(100).WithMessage("Nome muito grande");

            RuleFor(x => x.Publisher)
                .NotNull()
                .NotEmpty()
                .WithMessage("É necessário informar o editor.")
                .MinimumLength(3).WithMessage("Nome da editora muito curta")
                .MaximumLength(100).WithMessage("Nome da editora muito grande");
        }
    }
}
