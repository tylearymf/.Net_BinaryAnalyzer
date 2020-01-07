using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Misc;
using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Interface;
using System;
using System.IO;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.BinaryLibrary)]
    class Handler_BinaryLibrary : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            var record = new BinaryLibrary();
            record.LibraryId = analyze.Reader.ReadInt32();
            if (!Checker.CheckId(record.LibraryId))
            {
                analyze.Reader.BaseStream.Position -= 4;
                return null;
            }

            record.LibraryName = new LengthPrefixedString(analyze);

            return record;
        }
    }
}
