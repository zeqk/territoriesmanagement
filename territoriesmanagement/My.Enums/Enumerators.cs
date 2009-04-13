using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My
{
    public class Enumerators
    {
        public enum Criterias
        {
            EqualTo = 0,
            NotEqualTo = 1,
            StartsWith = 2,
            EndsWith = 3,
            Contains = 4
        }

        public enum ValueTypes
        {
            Number = 0,
            Text = 1,
            Date = 2
        }
    }
}
