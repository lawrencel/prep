using System;

namespace code.prep.people
{
  public interface ICalculate
  {
    int add(int i, int i1);
  }

  public class Calculator : ICalculate
  {
    public int add(int i, int i1)
    {
      if (i < 0 || i1 < 0) throw new NotImplementedException();
      return i + i1;
    }

  }
}