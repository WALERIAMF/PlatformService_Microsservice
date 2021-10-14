using FluentValidation;
using PlataformService.Domain.Request;

namespace PlataformService.Service.Validators

{
    public class GrupoPermissaoPostRequestValidator : AbstractValidator<GrupoPermissaoPostRequest>
    {
        public GrupoPermissaoPostRequestValidator()
        {

            RuleFor(x => x.Nome).NotNull().NotEmpty().WithMessage("É necessário informar o Nome.")
                .MinimumLength(3).WithMessage("Informar um nome maior")
                .MaximumLength(100).WithMessage("Nome muito grande");

        }
    }
}
