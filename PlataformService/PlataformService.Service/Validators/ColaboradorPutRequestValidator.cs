using FluentValidation;
using PlataformService.Domain.Request;

namespace PlataformService.Service.Validators

{
    public class ColaboradorPutRequestValidator : AbstractValidator<ColaboradorPutRequest>
    {
        public ColaboradorPutRequestValidator()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty().WithMessage("É necessário informar o Nome.")
                 .MinimumLength(3).WithMessage("Informar um nome maior")
                 .MaximumLength(100).WithMessage("Nome muito grande");

            RuleFor(e => e.Email).NotNull().NotEmpty()
                .WithMessage("O campo Email não pode ser nullo ou vazio!");
            RuleFor(e => e.Email).EmailAddress()
                .WithMessage("O campo Email deve ser enviado no formato de um e-mail!");
        }
    }
}
