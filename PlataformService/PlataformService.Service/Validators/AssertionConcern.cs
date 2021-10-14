using System;

namespace PlataformService.Service.Validators
{
    public static class AssertionConcern
    {
        public static void AssertArgumentNull(object obj, string message)
        {
            if (obj == null)
                throw new InvalidOperationException(message);
        }

        public static void AssertArgumentNotNull(object obj, string message)
        {
            if (obj != null)
                throw new InvalidOperationException(message);
        }

        public static void AssertArgumentCompareId(Guid firstId, Guid secondId, string message)
        {
            if (firstId != secondId)
                throw new InvalidOperationException(message);
        }
    }
}
