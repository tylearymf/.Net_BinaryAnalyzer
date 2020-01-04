using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using System;
using System.IO;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.ObjectNullMultiple256)]
    class Handler_ObjectNullMultiple256 : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            var record = new ObjectNullMultiple256();
            record.NullCount = analyze.Reader.ReadByte();

            return record;
        }
    }
}
