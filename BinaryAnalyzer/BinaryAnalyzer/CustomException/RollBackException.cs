using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.CustomException
{
    class RollBackException : System.Exception
    {
        public int Offset { protected set; get; }

        public RollBackException(int offset)
        {
            Offset = offset;
        }
    }
}
