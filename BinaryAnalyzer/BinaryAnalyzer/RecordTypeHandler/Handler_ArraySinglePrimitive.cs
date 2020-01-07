using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Interface;
using System;
using System.IO;

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

            if (record.PrimitiveTypeEnum == PrimitiveTypeEnumeration.Byte)
            {
                record.Value = analyze.Reader.ReadBytes(record.ArrayInfo.Length);
            }

            return record;
        }
    }
}
