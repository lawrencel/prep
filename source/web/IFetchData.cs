using System.Collections.Generic;
using code.prep.people;

namespace code.web
{
  public interface IFetchData
  {
    IEnumerable<Person> get_all_people();
  }
}