using BinaryAnalyzer.Struct;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Attribute
{
    class HandlerAttribute : System.Attribute
    {
        public RecordTypeEnumeration RecordType { set; get; }

        public HandlerAttribute(RecordTypeEnumeration recordType)
        {
            RecordType = recordType;
        }
    }
}
