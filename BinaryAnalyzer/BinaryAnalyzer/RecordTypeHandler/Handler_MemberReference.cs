using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Interface;
using System;
using System.IO;
using BinaryAnalyzer.Misc;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.MemberReference)]
    class Handler_MemberReference : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            var record = new MemberReference();
            record.IdRef = analyze.Reader.ReadInt32();
            Assert.IsIdRef(record.IdRef);

            return record;
        }
    }
}
