namespace code.utility.matching
{
  public class MatchingExtensionPoint<ItemToMatch, Property> : IProvideAccessToMatchBuilders<ItemToMatch, Property, Criteria<ItemToMatch>>
  {
    IGetTheValueOfAProperty<ItemToMatch, Property> accessor { get; }


    public MatchingExtensionPoint(IGetTheValueOfAProperty<ItemToMatch, Property> accessor)
    {
      this.accessor = accessor;
    }

        //whats the simpliest way to test this?
        //does it return a NegatingMatchingExtensionPoint with reference to the original?
        public IProvideAccessToMatchBuilders<ItemToMatch, Property,Criteria<ItemToMatch>> not
    {
      get { return new NegatingMatchingExtensionPoint(this); }
    }

        //decorator
    class NegatingMatchingExtensionPoint : IProvideAccessToMatchBuilders<ItemToMatch, Property, Criteria<ItemToMatch>>
    {
      IProvideAccessToMatchBuilders<ItemToMatch, Property, Criteria<ItemToMatch>> original;

      public NegatingMatchingExtensionPoint(IProvideAccessToMatchBuilders<ItemToMatch, Property, Criteria<ItemToMatch>> original)
      {
        this.original = original;
      }

      public Criteria<ItemToMatch> create(Criteria<Property> value_matcher)
      {
        return original.create(value_matcher).not();
      }
    }

    public Criteria<ItemToMatch> create(Criteria<Property> value_matcher)
    {
            //tell don't ask
      return x => value_matcher(accessor(x));
    }
  }
}