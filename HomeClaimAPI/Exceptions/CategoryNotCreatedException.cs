using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeClaimAPI.Exceptions
{
    public class CategoryNotCreatedException:ApplicationException
    {
        public CategoryNotCreatedException() { }
        public CategoryNotCreatedException(string message) : base(message) { }
    }
}
