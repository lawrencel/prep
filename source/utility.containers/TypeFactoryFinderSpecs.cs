using System;
using System.Collections.Generic;
using developwithpassion.specifications.assertions.core;
using developwithpassion.specifications.assertions.interactions;
using Machine.Specifications;
using Rhino.Mocks;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.utility.containers
{
    [Subject(typeof(TypeFactoryFinder))]
    public class TypeFactoryFinderSpecs 
    {
        public abstract class concern : spec.observe<IFindFactoriesForAType, TypeFactoryFinder>
        {
            
        }

        public class when_getting_resolver_for_type : concern
        {
            private Establish e = () =>
            {
                requestedType = typeof(SomeFunnyType);
                spec.change(() => TypeFactoryFinder.dictionary).to(new Dictionary<Type, IResolveType>());
            };

            private Because b = () =>
                sut.get_resolver_for_type(requestedType);

            It creates_dictionary_key_for_requested_type = () =>
                dictionary.should().received(x=> x.Add(requestedType,Arg<IResolveType>.Is.Anything));

            private static IDictionary<Type, IResolveType> dictionary;
            private static Type requestedType;
        }

        public class SomeFunnyType
        {
            
        }
    }


}