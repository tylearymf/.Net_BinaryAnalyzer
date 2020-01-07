using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.CustomException;
using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Interface;
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

            ClassWithMembersAndTypes record = null;

            try
            {
                record = new ClassWithMembersAndTypes();
                record.ClassInfo = new ClassInfo(analyze);
            }
            catch (RollBackException ex)
            {
                analyze.Reader.BaseStream.Position += ex.Offset;
                return null;
            }

            record.MemberTypeInfo = new MemberTypeInfo(analyze, record.ClassInfo.MemberCount);
            record.LibraryId = analyze.Reader.ReadInt32();

            return record;
        }
    }
}
