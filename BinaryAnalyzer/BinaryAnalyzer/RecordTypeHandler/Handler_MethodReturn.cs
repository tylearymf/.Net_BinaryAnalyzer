﻿using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Interface;
using System;
using System.IO;
using BinaryAnalyzer.Misc;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.MethodReturn)]
    class Handler_MethodReturn : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            var record = new BinaryMethodReturn();
            record.MessageEnum = (MessageFlags)analyze.Reader.ReadInt32();
            Assert.IsMessageFlags(record.MessageEnum);

            record.ReturnValue = new ValueWithCode(analyze);
            record.CallContext = new StringValueWithCode(analyze);

            if (record.MessageEnum == MessageFlags.ArgsInline)
            {
                record.Args = new ArrayOfValueWithCode(analyze);
            }

            return record;
        }
    }
}
