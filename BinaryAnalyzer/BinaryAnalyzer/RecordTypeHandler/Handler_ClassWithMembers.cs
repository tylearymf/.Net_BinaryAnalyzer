using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.CustomException;
using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Interface;
using System;
using System.IO;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.ClassWithMembers)]
    class Handler_ClassWithMembers : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            if (analyze.LastRecordType == RecordTypeEnumeration.ClassWithId) return null;

            var record = new ClassWithMembers();
            record.ClassInfo = new ClassInfo(analyze);
            record.LibraryId = analyze.Reader.ReadInt32();

            return record;
        }
    }
}
