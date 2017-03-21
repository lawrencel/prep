using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.utility.matching
{
    public class Range
    {        
        public static Criteria<Value> starting_with<Value>(Value value, bool inclusive = false)
            where Value : IComparable<Value>
        {
            return x =>
            {
                var result = GreaterThan.value(value)(x);
                if (!result && inclusive)
                    result = value.CompareTo(x) == 0;
                return result;
            };
        }

        public static Criteria<Value> ending_with<Value>(Value value, bool inclusive = false)
    where Value : IComparable<Value>
        {
            return x =>
            {
                var result = LessThan.value(value)(x);
                if (!result && inclusive)
                    result = value.CompareTo(x) == 0;
                return result;
            };
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
    }
}
