using System;
using System.Collections.Generic;

namespace code.utility.containers
{
    public class TypeFactoryFinder : IFindFactoriesForAType
    { 
        public ICreateOneDependency get_factory_that_can_create(Type item_to_create)
        {
            throw new NotImplementedException();
        }
    }
}