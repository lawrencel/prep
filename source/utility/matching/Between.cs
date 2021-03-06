﻿using System;

namespace code.utility.matching
{
  public class Between
  {
    public static Criteria<Value> values<Value>(Value start, Value end) where Value : IComparable<Value>
    {
      return x => x.CompareTo(start) >= 0 && x.CompareTo(end) <= 0;
    }
  }

  public static class BetweenMatchingExtensions
  {
    public static Criteria<Item> between<Item,Property>(this IProvideAccessToMatchBuilders<Item,Property> extension_point, Property start, Property end) where Property : IComparable<Property>
    {
      return extension_point.create(Between.values(start, end));
    }

  }
}