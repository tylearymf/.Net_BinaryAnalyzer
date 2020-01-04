using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    interface IRecordObject
    {
        RecordTypeEnumeration RecordTypeEnum { set; get; }
    }
}
