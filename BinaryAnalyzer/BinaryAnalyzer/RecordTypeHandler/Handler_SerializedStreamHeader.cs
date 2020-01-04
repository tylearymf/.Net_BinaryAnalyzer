using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using System;
using System.IO;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.SerializedStreamHeader)]
    class Handler_SerializedStreamHeader : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            var record = new SerializationHeaderRecord();
            record.RootId = analyze.Reader.ReadInt32();
            record.HeaderId = analyze.Reader.ReadInt32();
            record.MajorVersion = analyze.Reader.ReadInt32();
            record.MinorVersion = analyze.Reader.ReadInt32();

            return record;
        }
    }
}
