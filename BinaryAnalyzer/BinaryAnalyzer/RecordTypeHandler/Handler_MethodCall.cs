using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using System;
using System.IO;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.MethodCall)]
    class Handler_MethodCall : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            var record = new BinaryMethodCall();
            record.MessageEnum = (MessageFlags)analyze.Reader.ReadInt32();
            record.MethodName = new StringValueWithCode(analyze);
            record.TypeName = new StringValueWithCode(analyze);
            record.CallContext = new StringValueWithCode(analyze);

            if (record.MessageEnum == MessageFlags.ArgsInline)
            {
                record.Args = new ArrayOfValueWithCode(analyze);
            }

            return record;
        }
    }
}
