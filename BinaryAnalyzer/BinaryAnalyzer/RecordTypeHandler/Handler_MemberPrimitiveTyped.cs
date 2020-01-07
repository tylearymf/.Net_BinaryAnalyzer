using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Interface;
using System;
using System.IO;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.MemberPrimitiveTyped)]
    class Handler_MemberPrimitiveTyped : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            //if (analyze.LastRecordType == RecordTypeEnumeration.ClassWithId) return null;

            var record = new MemberPrimitiveTyped();
            record.PrimitiveTypeEnum = (PrimitiveTypeEnumeration)analyze.Reader.ReadByte();
            record.Value = Common.GetPrimitiveTypeValue(analyze, record.PrimitiveTypeEnum);

            return record;
        }
    }
}
