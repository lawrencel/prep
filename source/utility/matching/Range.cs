using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.utility.matching
{
    public class Range
    {        
        //build range types instead of criteria
        public static Criteria<Value> starting_with<Value>(Value value, bool inclusive = false)
            where Value : IComparable<Value>
        {
            return x => GreaterThan.value(value)(x) || (inclusive && EqualToAny.values(value)(x));
        }

        public static Criteria<Value> ending_with<Value>(Value value, bool inclusive = false)
    where Value : IComparable<Value>
        {
            return x => LessThan.value(value)(x) || (inclusive && EqualToAny.values(value)(x));
        }
    }

    public static class RangeExtensions
    {
        public static Criteria<Value> starting_with<Value>(this Criteria<Value> criteria, Value value, bool inclusive = false)
            where Value : IComparable<Value>
        {
            return Range.starting_with(value, inclusive);
        }
        public static Criteria<Value> ending_with<Value>(this Criteria<Value>criteria, Value value, bool inclusive = false)
            where Value : IComparable<Value>
        {
            return Range.ending_with(value, inclusive);
        }

        public static Criteria<Item> falls_in<Item, Property>(this IProvideAccessToMatchBuilders<Item, Property> extension_point, Criteria<Property> rangeCriteria) where Property : IComparable<Property>
        {
            return extension_point.create(rangeCriteria);
        }
    }
}
