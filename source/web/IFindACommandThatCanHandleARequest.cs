namespace code.web
{
  public interface IFindACommandThatCanHandleARequest
  {
    void get_command_that_can_handle(IProvideDetailsAboutAWebRequest request);
  }
}