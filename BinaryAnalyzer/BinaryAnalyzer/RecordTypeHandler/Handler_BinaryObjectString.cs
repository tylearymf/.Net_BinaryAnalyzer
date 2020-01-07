using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Misc;
using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Interface;
using System;
using System.IO;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.BinaryObjectString)]
    class Handler_BinaryObjectString : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            ////
            //if (analyze.LastObject is ClassWithId) return null;

            var record = new BinaryObjectString();
            record.ObjectId = analyze.Reader.ReadInt32();

            if (!Checker.CheckId(record.ObjectId))
            {
                analyze.Reader.BaseStream.Position -= 4;
                return null;
            }

            record.Value = new LengthPrefixedString(analyze);

            return record;
        }
    }
}
