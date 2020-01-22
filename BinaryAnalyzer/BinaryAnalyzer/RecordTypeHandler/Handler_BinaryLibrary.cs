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
            Assert.IsLibraryId(record.LibraryId);

            record.LibraryName = new LengthPrefixedString(analyze);

            return record;
        }
    }
}
