using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using System;
using System.IO;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.ClassWithMembersAndTypes)]
    class Handler_ClassWithMembersAndTypes : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            if (analyze.LastRecordType == RecordTypeEnumeration.ClassWithId) return null;

            var record = new ClassWithMembersAndTypes();
            record.ClassInfo = new ClassInfo(analyze);
            record.MemberTypeInfo = new MemberTypeInfo(analyze, record.ClassInfo.MemberCount);
            record.LibraryId = analyze.Reader.ReadInt32();

            return record;
        }
    }
}
