using System;
using System.Collections.Generic;
using System.Linq;
using developwithpassion.specifications.assertions.core;
using developwithpassion.specifications.assertions.interactions;
using developwithpassion.specifications.extensions;
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
                dependencyCreators = depends.@on<IEnumerable<ICreateOneDependency>>();
                expectedDependencyCreator = dependencyCreators.First();                
                expectedDependencyCreator.setup(x => x.canCreate(requestedType)).Return(true);            
            };

            private Because b = () =>
                sut.get_factory_that_can_create(requestedType);

            It should_have_returned_expected_dependency_creator = () =>
                result.ShouldEqual(expectedDependencyCreator);                

            private static IEnumerable<ICreateOneDependency> dependencyCreators;
            private static ICreateOneDependency expectedDependencyCreator;
            private static Type requestedType;
            private static ICreateOneDependency result;
        }

        public class SomeFunnyType
        {

        }
    }


}