using BinaryAnalyzer.RecordTypeHandler;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    class LengthPrefixedString : BaseDeserializeObject
    {
        public LengthPrefixedString(IAnalyze analyze) : base(analyze)
        {
            Value = analyze.Reader.ReadString();
        }

        public string Value { set; get; }

        public override string ToString()
        {
            return Value;
        }
    }
}
