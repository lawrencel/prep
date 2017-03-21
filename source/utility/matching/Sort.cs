using System;

namespace code.utility.matching
{
    public static class Sort<Item>
    {
        public static ICompareTwoItems<Item> by_descending<Property>(IGetTheValueOfAProperty<Item,Property> propertyGetter)
            where Property : IComparable<Property>
        {
            return (first, second) => propertyGetter(second).CompareTo(propertyGetter(first));
        }
    }
}