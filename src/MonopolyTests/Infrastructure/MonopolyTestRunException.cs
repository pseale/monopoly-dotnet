using System;

namespace MonopolyTests.Infrastructure
{
  public class MonopolyTestRunException : Exception
  {
    private readonly string _message;

    public MonopolyTestRunException(string message)
      :base(message)
    {
      _message = message;
    }

    public override string ToString()
    {
      return _message;
    }
  }
}