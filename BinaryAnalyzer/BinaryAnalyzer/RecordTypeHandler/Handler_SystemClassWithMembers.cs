using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.CustomException;
using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Interface;
using System;
using System.IO;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.SystemClassWithMembers)]
    class Handler_SystemClassWithMembers : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            if (analyze.LastRecordType == RecordTypeEnumeration.ClassWithId) return null;

            var record = new SystemClassWithMembers();
            record.ClassInfo = new ClassInfo(analyze);

            return record;
        }
    }
}
