using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Misc;
using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Interface;
using System;
using System.IO;
using BinaryAnalyzer.CustomException;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.BinaryArray)]
    class Handler_BinaryArray : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            var record = new BinaryArray();

            record.ObjectId = analyze.Reader.ReadInt32();
            Assert.IsObjectId(record.ObjectId);

            record.BinaryArrayTypeEnum = (BinaryArrayTypeEnumeration)analyze.Reader.ReadByte();
            Assert.IsBinaryArrayTypeEnum(record.BinaryArrayTypeEnum);

            record.Rank = analyze.Reader.ReadInt32();
            Assert.IsPositiveIntegerIncludeZero(record.Rank);

            record.Lengths = new Int32[record.Rank];
            for (int i = 0; i < record.Rank; i++)
            {
                record.Lengths[i] = analyze.Reader.ReadInt32();
                Assert.IsPositiveIntegerIncludeZero(record.Lengths[i]);
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
            Assert.IsBinaryTypeEnum(record.TypeEnum);

            record.AdditionalTypeInfo = Common.GetBinaryTypeValue(analyze, record.TypeEnum);

            return record;
        }
    }
}
