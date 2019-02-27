using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeClaimAPI.Exceptions
{
    public class CategoryNotFoundException:ApplicationException
    {
        public CategoryNotFoundException() { }
        public CategoryNotFoundException(string message) : base(message) { }
    }
}
