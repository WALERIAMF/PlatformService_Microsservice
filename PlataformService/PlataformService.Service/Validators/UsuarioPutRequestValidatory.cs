using FluentValidation;
using PlataformService.Domain.Request;

namespace PlataformService.Service.Validators

{
    public class UsuarioPutRequestValidator : AbstractValidator<UsuarioPutRequest>
    {
        public UsuarioPutRequestValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("É necessário informar o Id.");

            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage("É necessário informar o Nome.")
                .MinimumLength(3).WithMessage("Informar um nome maior")
                .MaximumLength(100).WithMessage("Nome muito grande");

            RuleFor(x => x.Login)
                .NotNull()
                .NotEmpty()
                .WithMessage("É necessário informar o login.")
                .MinimumLength(4).WithMessage("Login muito curta")
                .MaximumLength(10).WithMessage("Login muito grande");

            RuleFor(x => x.Senha)
                .NotNull()
                .NotEmpty()
                .MaximumLength(12).WithMessage("Senha muito grande");
        }
    }
}
