using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Interface;
using System;
using System.IO;
using BinaryAnalyzer.CustomException;
using BinaryAnalyzer.Misc;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.MethodCall)]
    class Handler_MethodCall : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            var record = new BinaryMethodCall();
            record.MessageEnum = (MessageFlags)analyze.Reader.ReadInt32();
            Assert.IsMessageFlags(record.MessageEnum);

            record.MethodName = new StringValueWithCode(analyze);
            Assert.IsMemberName(record.MethodName.StringValue.Value);

            record.TypeName = new StringValueWithCode(analyze);
            Assert.IsMemberName(record.TypeName.StringValue.Value);

            record.CallContext = new StringValueWithCode(analyze);

            if (record.MessageEnum == MessageFlags.ArgsInline)
            {
                record.Args = new ArrayOfValueWithCode(analyze);
            }

            return record;
        }
    }
}
