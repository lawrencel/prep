using System;
using System.Collections.Generic;
using System.Linq;

namespace code.web
{
  public class CommandRegistry :IFindACommandThatCanHandleARequest
  {
      private readonly IEnumerable<IHandleOneWebRequest> _requestHandlers;

      public CommandRegistry(IEnumerable<IHandleOneWebRequest> requestHandlers)
      {
          _requestHandlers = requestHandlers;
      }
     public IHandleOneWebRequest get_command_that_can_handle(IProvideDetailsAboutAWebRequest request)
     {
         return _requestHandlers.First(x=>x.can_process(request));
     }
  }
}