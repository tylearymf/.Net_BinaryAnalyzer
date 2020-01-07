using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Interface
{
    interface IRecordObject
    {
        RecordTypeEnumeration RecordTypeEnum { set; get; }
    }
}
