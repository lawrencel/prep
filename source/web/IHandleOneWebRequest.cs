namespace code.web
{
  public interface IHandleOneWebRequest
  {
    void process(IProvideDetailsAboutAWebRequest request);
    bool can_process(IProvideDetailsAboutAWebRequest request);
  }
}