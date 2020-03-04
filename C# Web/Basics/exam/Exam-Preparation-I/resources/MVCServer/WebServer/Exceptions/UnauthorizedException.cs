namespace WebServer.Exceptions
{
    using System;

    public class UnauthorizedException : Exception
    {
        private const string UnathorizedMessage = "You are not authroized to perform this task.";

        public static object ThrowFromInvalidRequest()
            => throw new BadRequestException(UnathorizedMessage);

        public UnauthorizedException(string message)
            : base(message)
        {
        }
    }
}
