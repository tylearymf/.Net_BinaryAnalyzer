using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Interface;
using System;
using System.IO;
using BinaryAnalyzer.Misc;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.MemberPrimitiveTyped)]
    class Handler_MemberPrimitiveTyped : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            var record = new MemberPrimitiveTyped();

            record.PrimitiveTypeEnum = (PrimitiveTypeEnumeration)analyze.Reader.ReadByte();
            Assert.IsPrimitiveTypeEnum(record.PrimitiveTypeEnum);

            record.Value = Common.GetPrimitiveTypeValue(analyze, record.PrimitiveTypeEnum);

            return record;
        }
    }
}
