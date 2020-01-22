using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Interface;
using System;
using System.IO;
using BinaryAnalyzer.CustomException;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.ArraySingleObject)]
    class Handler_ArraySingleObject : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            var record = new ArraySingleObject();
            record.ArrayInfo = new ArrayInfo(analyze);

            return record;
        }
    }
}
