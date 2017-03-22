namespace code.web
{
  public class FrontController
  {
      private readonly IFindACommandThatCanHandleARequest _commands;

      public FrontController(IFindACommandThatCanHandleARequest commands)
      {
          _commands = commands;
      }

      public void run(IProvideDetailsAboutAWebRequest request)
      {
          _commands.get_command_that_can_handle(request);
      }
  }
}