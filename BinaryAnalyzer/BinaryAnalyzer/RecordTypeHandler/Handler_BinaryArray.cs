using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Misc;
using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Interface;
using System;
using System.IO;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.BinaryArray)]
    class Handler_BinaryArray : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            var record = new BinaryArray();
            record.ObjectId = analyze.Reader.ReadInt32();

            if (!Checker.CheckId(record.ObjectId))
            {
                analyze.Reader.BaseStream.Position -= 4;
                return null;
            }

            record.BinaryArrayTypeEnum = (BinaryArrayTypeEnumeration)analyze.Reader.ReadByte();
            record.Rank = analyze.Reader.ReadInt32();
            record.Lengths = new Int32[record.Rank];
            for (int i = 0; i < record.Rank; i++)
            {
                record.Lengths[i] = analyze.Reader.ReadInt32();
            }
            record.LowerBounds = new Int32[record.Rank];
            for (int i = 0; i < record.Rank; i++)
            {
                if (record.BinaryArrayTypeEnum == BinaryArrayTypeEnumeration.SingleOffset ||
                    record.BinaryArrayTypeEnum == BinaryArrayTypeEnumeration.JaggedOffset ||
                    record.BinaryArrayTypeEnum == BinaryArrayTypeEnumeration.RectangularOffset)
                {
                    record.LowerBounds[i] = analyze.Reader.ReadInt32();
                }
                else
                {
                    record.LowerBounds[i] = 0;
                }
            }
            record.TypeEnum = (BinaryTypeEnumeration)analyze.Reader.ReadByte();
            record.AdditionalTypeInfo = Common.GetBinaryTypeValue(analyze, record.TypeEnum);

            return record;
        }
    }
}
