using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using System;
using System.IO;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.BinaryObjectString)]
    class Handler_BinaryObjectString : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            ////
            //if (analyze.LastObject is ClassWithId) return null;

            var record = new BinaryObjectString();
            record.ObjectId = analyze.Reader.ReadInt32();
            record.Value = new LengthPrefixedString(analyze);

            return record;
        }
    }
}
