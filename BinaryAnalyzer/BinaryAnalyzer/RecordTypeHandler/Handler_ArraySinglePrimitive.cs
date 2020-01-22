using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Interface;
using System;
using System.IO;
using BinaryAnalyzer.CustomException;
using BinaryAnalyzer.Misc;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.ArraySinglePrimitive)]
    class Handler_ArraySinglePrimitive : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            var record = new ArraySinglePrimitive();
            record.ArrayInfo = new ArrayInfo(analyze);
            record.PrimitiveTypeEnum = (PrimitiveTypeEnumeration)analyze.Reader.ReadByte();
            Assert.IsPrimitiveTypeEnum(record.PrimitiveTypeEnum);

            if (record.PrimitiveTypeEnum == PrimitiveTypeEnumeration.Byte)
            {
                record.Value = analyze.Reader.ReadBytes(record.ArrayInfo.Length);
            }

            return record;
        }
    }
}
