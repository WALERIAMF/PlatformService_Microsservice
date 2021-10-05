using System;

namespace PlataformService.Domain.Exceptions
{
    public class CadastroDomainException : Exception
    {
        public CadastroDomainException()
        { }

        public CadastroDomainException(string message)
            : base(message)
        { }

        public CadastroDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
