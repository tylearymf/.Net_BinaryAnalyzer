using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using System;
using System.IO;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.ClassWithId)]
    class Handler_ClassWithId : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            var record = new ClassWithId();
            record.ObjectId = analyze.Reader.ReadInt32();
            record.MetadataId = analyze.Reader.ReadInt32();

            return record;
        }
    }
}
