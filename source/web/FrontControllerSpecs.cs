using developwithpassion.specifications.assertions.core;
using developwithpassion.specifications.assertions.interactions;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;
using Machine.Specifications;


namespace code.web
{   

  [Subject(typeof(FrontController))]
  public class FrontControllerSpecs
  {

    public abstract class concern : spec.observe<FrontController>
    {
        
    }

    public class when_processing_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsAboutAWebRequest>();
        commands = depends.on<IFindACommandThatCanHandleARequest>();
      };

      Because b = () =>
        sut.run(request);

      It finds_the_the_command_that_can_process_the_request = () =>
        commands.should().received(x => x.get_command_that_can_handle(request));

      static IFindACommandThatCanHandleARequest commands;
      static IProvideDetailsAboutAWebRequest request;
    }
  }
}
