using System;
using System.Data;

namespace code.prep.people
{
  public interface ICalculate
  {
    int add(int i, int i1);
  }

  public class Calculator : ICalculate
  {
    private IDbConnection connection;

    public Calculator(IDbConnection connection)
    {
      this.connection = connection;
    }

    public int add(int i, int i1)
    {
      if (i < 0 || i1 < 0) throw new NotImplementedException();
      connection.Open();
      return i + i1;
    }

  }
}