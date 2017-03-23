using System;
using System.Collections.Generic;

namespace code.utility.containers
{
    public class TypeFactoryFinder : IFindFactoriesForAType
    {
        public static IDictionary<Type, IResolveType> dictionary
        {
            get
            {
                throw new NotImplementedException("Replace this in constructor ;)");
            }
        }
        public void get_resolver_for_type(Type the_type)
        {
            throw new NotImplementedException();
        }
    }
}