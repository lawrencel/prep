using System;

namespace code.web
{
  public class CommandRegistry :IFindACommandThatCanHandleARequest
  {
     public IHandleOneWebRequest get_command_that_can_handle(IProvideDetailsAboutAWebRequest request)
     {
       throw new NotImplementedException();
     }
  }
}