using System;
using System.Collections.Generic;
using System.Linq;
using code.utility.visitors;
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

        public class when_getting_resolver_for_non_Iterator_type : concern
        {
            Establish e = () =>
            {
                requestedType = typeof(SomeFunnyType);
                dependencyCreators = depends.@on<IEnumerable<ICreateOneDependency>>();
                expectedDependencyCreator = dependencyCreators.Last();                
                expectedDependencyCreator.setup(x => x.canCreate(requestedType)).Return(true);            
            };

            Because b = () =>
                result = sut.get_factory_that_can_create(requestedType);

            It returns_expected_dependency_creator = () =>
                result.ShouldEqual(expectedDependencyCreator);                

            private static IEnumerable<ICreateOneDependency> dependencyCreators;
            private static ICreateOneDependency expectedDependencyCreator;
            private static Type requestedType;
            private static ICreateOneDependency result;
        }

        public class when_getting_resolver_for_Iterator_type : concern
        {
            Establish e = () =>
            {
                requestedType = typeof(IEnumerable<SomeFunnyType>);
                dependencyCreators = depends.@on<IEnumerable<ICreateOneDependency>>();
                dependencyCreators.Last().setup(x => x.canCreate(requestedType)).Return(true);
                dependencyCreators.First().setup(x => x.canCreate(requestedType)).Return(true);

                expectedDependencyCreator = new List<ICreateOneDependency>()
                {
                    dependencyCreators.First(),
                    dependencyCreators.Last()
                };
            };

            Because b = () =>
                result = sut.get_factory_that_can_create(requestedType);

            private It returns_expeced_dependencyCreators = () =>
                (result as IEnumerable<SomeFunnyType>).each_for_all(
                    element => expectedDependencyCreator.ShouldContain(element));

            It returns_IEnumerable_of_SomeFunnyType = () =>
                result.ShouldBeAssignableTo(typeof(IEnumerable<SomeFunnyType>));

            private static IEnumerable<ICreateOneDependency> dependencyCreators;
            private static Type requestedType;
            private static ICreateOneDependency result;
            private static IEnumerable<ICreateOneDependency> expectedDependencyCreator;
        }

        public class SomeFunnyType
        {

        }
    }


}