using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Interface;
using System;
using System.IO;
using BinaryAnalyzer.Misc;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.ObjectNullMultiple)]
    class Handler_ObjectNullMultiple : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            var record = new ObjectNullMultiple();

            record.NullCount = analyze.Reader.ReadInt32();
            Assert.IsPositiveIntegerIncludeZero(record.NullCount);

            return record;
        }
    }
}
