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

        public static ICompareTwoItems<Item> by<Property>(IGetTheValueOfAProperty<Item, Property> propertyGetter)
            where Property : IComparable<Property>
        {
            return (first, second) => propertyGetter(first).CompareTo(propertyGetter(second));
        }

        public static ICompareTwoItems<Item> by<Property>(IGetTheValueOfAProperty<Item, Property> propertyGetter,
            params Property[] priority)
        {
            //use array index of
        }
    }

    public static class SortExtensions
    {
        public static ICompareTwoItems<Item> then_by<Item, NextProperty>(this ICompareTwoItems<Item> sortedByFirstProperty, IGetTheValueOfAProperty<Item, NextProperty> nextpropertyGetter)
            where NextProperty : IComparable<NextProperty>
        {
            return (first, second) =>
            {
                var previousResult = sortedByFirstProperty(first, second);
                return previousResult == 0 ? Sort<Item>.@by(nextpropertyGetter)(first, second) : 0;
            };
        }
    }
}