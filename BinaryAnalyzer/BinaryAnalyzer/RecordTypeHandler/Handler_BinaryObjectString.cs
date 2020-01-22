using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Misc;
using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Interface;
using System;
using System.IO;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.BinaryObjectString)]
    class Handler_BinaryObjectString : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            var record = new BinaryObjectString();

            record.ObjectId = analyze.Reader.ReadInt32();
            Assert.IsObjectId(record.ObjectId);

            record.Value = new LengthPrefixedString(analyze);

            return record;
        }
    }
}
