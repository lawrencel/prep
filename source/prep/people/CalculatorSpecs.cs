using System.Data;
using developwithpassion.specifications.assertions.core;
using developwithpassion.specifications.assertions.interactions;
using Machine.Specifications;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.prep.people
{
  [Subject(typeof(Calculator))]
  public class CalculatorSpecs
  {
    public abstract class concern : spec.observe<ICalculate, Calculator>
    {
      protected static IDbConnection connection;

      Establish c = () =>
      {
        connection = depends.on<IDbConnection>();
      };
    }

    public class when_adding : concern
    {
      public class two_positive_numbers
      {
        Because b = () =>
          result = sut.add(2, 3);

        It opens_a_database_connection = () =>
          connection.should().received(x => x.Open());

        It returns_the_sum = () =>
          result.ShouldEqual(5);

        static int result;
      }

      public class negative_to_a_positive
      {
        Because b = () =>
          spec.catch_exception(() => sut.add(2, -6));

        It cannot_handle_it = () =>
          spec.exception_thrown.ShouldNotBeNull();
      }
    }
  }
}