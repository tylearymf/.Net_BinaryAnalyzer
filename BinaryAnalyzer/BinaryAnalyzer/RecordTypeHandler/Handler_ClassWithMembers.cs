using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using System;
using System.IO;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.ClassWithMembers)]
    class Handler_ClassWithMembers : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            var record = new ClassWithMembers();
            record.ClassInfo = new ClassInfo(analyze);
            record.LibraryId = analyze.Reader.ReadInt32();

            return record;
        }
    }
}
