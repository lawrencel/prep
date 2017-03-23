using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.assertions.core;
using developwithpassion.specifications.assertions.interactions;
using Rhino.Mocks;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.utility.iteration
{
  public class VisitorSpikes
  {
    public abstract class concern : spec.observe
    {

    }

    public class when_processing_all_of_the_items_in_a_iterator : concern
    {
      Establish c = () =>
      {
        visitor = fake.an<IProcessAn<int>>();
      };

      Because b = () =>
        Enumerable.Range(1, 10).process_all_using(visitor);

      It processes_each_item_using_the_visitor = () =>
        visitor.should().received(x => x.process(Arg<int>.Is.Anything)).Times(10);

      static IProcessAn<int> visitor;
        
        
    }
  }
}
