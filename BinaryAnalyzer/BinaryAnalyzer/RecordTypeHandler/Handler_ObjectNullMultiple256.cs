using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Interface;
using System;
using System.IO;
using BinaryAnalyzer.Misc;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.ObjectNullMultiple256)]
    class Handler_ObjectNullMultiple256 : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            var record = new ObjectNullMultiple256();

            record.NullCount = analyze.Reader.ReadByte();
            Assert.IsPositiveIntegerIncludeZero(record.NullCount);

            return record;
        }
    }
}
