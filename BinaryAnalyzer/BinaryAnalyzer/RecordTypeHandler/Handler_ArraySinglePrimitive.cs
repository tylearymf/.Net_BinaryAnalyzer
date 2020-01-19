using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Interface;
using System;
using System.IO;
using BinaryAnalyzer.CustomException;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.ArraySinglePrimitive)]
    class Handler_ArraySinglePrimitive : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            var record = new ArraySinglePrimitive();

            try
            {
                record.ArrayInfo = new ArrayInfo(analyze);
            }
            catch (RollBackException ex)
            {
                analyze.Reader.BaseStream.Position += ex.Offset;
                return null;
            }

            record.PrimitiveTypeEnum = (PrimitiveTypeEnumeration)analyze.Reader.ReadByte();
            if (record.PrimitiveTypeEnum == PrimitiveTypeEnumeration.Byte)
            {
                record.Value = analyze.Reader.ReadBytes(record.ArrayInfo.Length);
            }

            return record;
        }
    }
}
