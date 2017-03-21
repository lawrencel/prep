using System;
using code.utility;
using code.utility.matching;

namespace code.prep.movies
{
  public class Sort<Item>
  {
    public static ICompareTwoItems<Item> by_descending<Property>(IGetTheValueOfAProperty<Item, Property> accessor) where Property : IComparable<Property>
    {
      return (a, b) => -by(accessor)(a, b);
    }

    public static ICompareTwoItems<Item> by<Property>(IGetTheValueOfAProperty<Item, Property> accessor) where Property : IComparable<Property>
    {
      return (a, b) => accessor(a).CompareTo(accessor(b));
    }

  }
}