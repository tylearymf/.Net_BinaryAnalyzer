using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using System;
using System.IO;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.ObjectNullMultiple)]
    class Handler_ObjectNullMultiple : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            var record = new ObjectNullMultiple();
            record.NullCount = analyze.Reader.ReadInt32();

            return record;
        }
    }
}
