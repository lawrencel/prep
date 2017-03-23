using System;

namespace code.utility.containers
{
    public interface IFindFactoriesForAType
    {
        void get_resolver_for_type(Type the_type);
    }
}