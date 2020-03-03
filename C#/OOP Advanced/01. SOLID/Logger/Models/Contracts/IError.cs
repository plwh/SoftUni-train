namespace Logger.Models.Contracts
{
    using System;

    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        ErrorLevel Level { get; }
    }
}