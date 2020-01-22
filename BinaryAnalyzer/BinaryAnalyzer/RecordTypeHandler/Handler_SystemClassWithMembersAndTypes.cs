using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.CustomException;
using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Interface;
using System;
using System.IO;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.SystemClassWithMembersAndTypes)]
    class Handler_SystemClassWithMembersAndTypes : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            if (analyze.LastRecordType == RecordTypeEnumeration.ClassWithId) return null;

            var record = new SystemClassWithMembersAndTypes();
            record.ClassInfo = new ClassInfo(analyze);
            record.MemberTypeInfo = new MemberTypeInfo(analyze, record.ClassInfo.MemberCount);

            return record;
        }
    }
}
