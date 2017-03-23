﻿using System;
using System.Collections.Generic;
using code.utility.core;

namespace code.utility.iteration
{
  public static class VisitorExtensions
  {
    public static Result get_result_of_processing_all_with<Element, Result>(this IEnumerable<Element> items,
      IProcessAndReturnAValue<Element, Result> visitor)
    {
      items.each_for_all(visitor.process);
      return visitor.get_result();
    }

    public static void process_all_using<Element>(this IEnumerable<Element> items, IProcessAn<Element> visitor)
    {
      items.each_for_all(visitor.process);
    }

    public static void each_for_all<Element>(this IEnumerable<Element> items, ExhaustiveElementVisitor<Element> visitor)
    {
      items.each(x =>
      {
        visitor(x);
        return true;
      });
    }

    public static void each<Element>(this IEnumerable<Element> items, ElementVisitor<Element> visitor)
    {
      foreach (var element in items)
      {
        var result = visitor(element);
        if (!result) return;
      }
    }

    public static Element reduce<Element, Value>(this IEnumerable<Value> items, Element start,
      ElementAccumulator<Element, Value> element_accumulator)
    {
      var result = start;

      items.each(x =>
      {
        result = element_accumulator(result, x);
        return true;
      });

      return result;
    }
     
  }
}