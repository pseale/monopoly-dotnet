using System;

namespace MonopolyTests.Infrastructure
{
  public class TestRunException : Exception
  {
    private readonly string _message;

    public TestRunException(string message)
    {
      _message = message;
    }

    public override string ToString()
    {
      return _message;
    }
  }
}