using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using System;
using System.IO;


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
