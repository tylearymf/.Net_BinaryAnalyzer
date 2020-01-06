using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.CustomException;
using BinaryAnalyzer.Struct;
using System;
using System.IO;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.SystemClassWithMembers)]
    class Handler_SystemClassWithMembers : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            //
            if (analyze.LastRecordType == RecordTypeEnumeration.ClassWithId) return null;

            SystemClassWithMembers record = null;
            var pos = analyze.Reader.BaseStream.Position;

            try
            {
                record = new SystemClassWithMembers();
                record.ClassInfo = new ClassInfo(analyze);
            }
            catch (RollBackException ex)
            {
                analyze.Reader.BaseStream.Position = pos;
                return null;
            }

            return record;
        }
    }
}
