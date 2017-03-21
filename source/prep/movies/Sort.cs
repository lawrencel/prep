using System;
using code.utility;
using code.utility.matching;

namespace code.prep.movies
{
    public static class SortOrder
        
    {
        public static int ascending<Item>(Item a, Item b) where Item : IComparable<Item>
        {
            return a.CompareTo(b);
        }
        public static int descending<Item>(Item a, Item b) where Item : IComparable<Item>
        {
            return b.CompareTo(a);
        }
    }

    public interface IApplyComparison<Item>
    {
        ICompareTwoItems<Item> applyComparison();
    }

    public class RegularCompare<Item> : IApplyComparison<Item>
        where Item: IComparable<Item>
    {
        public ICompareTwoItems<Item> applyComparison()
        {
            return (first, second) => first.CompareTo(second);
        }
    }

    public class ReverseCompare<Item> : IApplyComparison<Item>
        where Item : IComparable<Item>
    {
        public ICompareTwoItems<Item> applyComparison()
        {
            return (first, second) => second.CompareTo(first);
        }
    }
    public class Sort<Item>
  {
    public static ICompareTwoItems<Item> by<Property>(IGetTheValueOfAProperty<Item, Property> accessor, ICompareTwoItems<Property> orderer) where Property : IComparable<Property>
    {
      return (first, second) => orderer(accessor(first), accessor(second));
    }

    public static ICompareTwoItems<Item> by<Property>(IGetTheValueOfAProperty<Item, Property> accessor, params Property[] sort_order)
    {
      return (a, b) => Array.IndexOf(sort_order, accessor(a)) - Array.IndexOf(sort_order, accessor(b));
    }
  }

  public static class SortExtensions
  {
    public static ICompareTwoItems<Item> then_by<Item, Property>(this ICompareTwoItems<Item> previous_comparer, IGetTheValueOfAProperty<Item, Property> accessor) where Property : IComparable<Property>
    {
      return (a, b) =>
      {
        var previous_result = previous_comparer(a, b);
        return previous_result == 0 ? Sort<Item>.by(accessor)(a, b) : previous_result;
      };
    }

  }
}