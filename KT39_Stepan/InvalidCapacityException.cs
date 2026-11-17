using System;

public class InvalidCapacityException : Exception
{
    public InvalidCapacityException(string message) : base(message) { }
}