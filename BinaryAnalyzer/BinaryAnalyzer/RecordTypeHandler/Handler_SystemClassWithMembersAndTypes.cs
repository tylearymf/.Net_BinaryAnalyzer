using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using System;
using System.IO;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.SystemClassWithMembersAndTypes)]
    class Handler_SystemClassWithMembersAndTypes : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            var record = new SystemClassWithMembersAndTypes();
            record.ClassInfo = new ClassInfo(analyze);
            record.MemberTypeInfo = new MemberTypeInfo(analyze, record.ClassInfo.MemberCount);

            return record;
        }
    }
}
