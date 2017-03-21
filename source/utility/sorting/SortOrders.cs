using System;

namespace code.utility.sorting
{
  public class SortOrders
  {
        //uses of strategy
        //passed as parameters. have the some contract
    public static int ascending<Item>(Item a, Item b) where Item : IComparable<Item>
    {
      return a.CompareTo(b);
    }

    public static int descending<Item>(Item a, Item b) where Item : IComparable<Item>
    {
      return b.CompareTo(a);
    }
  }
}