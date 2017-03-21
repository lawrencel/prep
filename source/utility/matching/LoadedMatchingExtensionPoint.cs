using System.Collections.Generic;

namespace code.utility.matching
{
    public class LoadedMatchingExtensionPoint<ItemToMatch, Property> : IProvideAccessToMatchBuilders<ItemToMatch, Property>
    {
        IGetTheValueOfAProperty<ItemToMatch, Property> accessor { get; }
        public IEnumerable<ItemToMatch> items { get; }


        public LoadedMatchingExtensionPoint(IGetTheValueOfAProperty<ItemToMatch, Property> accessor, IEnumerable<ItemToMatch> items)
        {
            this.accessor = accessor;
            this.items = items;
        }

        public IProvideAccessToMatchBuilders<ItemToMatch, Property> not
        {
            get { return new NegatingMatchingExtensionPoint(this); }
        }

        class NegatingMatchingExtensionPoint : IProvideAccessToMatchBuilders<ItemToMatch, Property>
        {
            IProvideAccessToMatchBuilders<ItemToMatch, Property> original;

            public NegatingMatchingExtensionPoint(IProvideAccessToMatchBuilders<ItemToMatch, Property> original)
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
            return x => value_matcher(accessor(x));
        }
    }
}