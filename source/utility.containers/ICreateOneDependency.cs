using System;

namespace code.utility.containers
{
  public interface ICreateOneDependency
  {
    object create();
      bool canCreate(Type type);
  }
}