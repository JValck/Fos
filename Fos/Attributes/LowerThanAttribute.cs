using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fos.Attributes
{
    public class LowerThanAttribute : NumericCompareAttribute
    {
        public LowerThanAttribute(string otherPropertyName) : base(otherPropertyName)
        {
        }

        protected override bool ValidCompare(int current, int other)
        {
            return current < other;
        }
    }
}
