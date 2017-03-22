using developwithpassion.specifications.assertions.core;
using developwithpassion.specifications.assertions.interactions;
using Machine.Specifications;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.web.features.list_people
{
  [Subject(typeof(Handler))]
  public class HandlerSpecs
  {

    public abstract class concern : spec.observe<IImplementAUserStory, Handler>
    {
        
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsAboutAWebRequest>();
        data_store = depends.on<IFetchData>();
      };

      Because b = () =>
        sut.process(request);

      It gets_the_list_of_people_from_the_datastore = () =>
        data_store.should().received(x => x.get_all_people());

      static IFetchData data_store;
      static IProvideDetailsAboutAWebRequest request;
    }
  }
}