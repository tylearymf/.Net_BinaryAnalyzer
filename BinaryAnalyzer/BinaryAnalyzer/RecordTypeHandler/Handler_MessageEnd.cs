using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Interface;
using System;
using System.IO;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.MessageEnd)]
    class Handler_MessageEnd : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            var record = new MessageEnd();

            return record;
        }
    }
}
