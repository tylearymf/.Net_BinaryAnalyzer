using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Interface;
using System;
using System.IO;
using BinaryAnalyzer.CustomException;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.ArraySingleString)]
    class Handler_ArraySingleString : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            var record = new ArraySingleString();
            record.ArrayInfo = new ArrayInfo(analyze);

            return record;
        }
    }
}
