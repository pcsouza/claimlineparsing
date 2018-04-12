using System;
using System.Collections.Generic;
using System.Text;

namespace ClaimLineParsing.Model
{
    public abstract class ClaimLineFieldBase<T> where T : ClaimLineFieldBase<T>
    {
        public abstract (T, bool) Parse(string inputField);
    }
}
