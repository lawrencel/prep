namespace code.web.features.list_people
{
  public class Handler : IImplementAUserStory
  {
      private readonly  IFetchData _dataFetcher;

      public Handler(IFetchData dataFetcher)
      {
            _dataFetcher = dataFetcher;
      }


      public void process(IProvideDetailsAboutAWebRequest request)
      {
          _dataFetcher.get_all_people();
      }
  }
}