using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Misc;
using BinaryAnalyzer.Struct;
using BinaryAnalyzer.Interface;
using System;
using System.IO;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.ClassWithId)]
    class Handler_ClassWithId : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            //ClassWithId不可能连续出现两次以上
            if (analyze.LastRecordType == RecordTypeEnumeration.ClassWithId) return null;
            //
            if (analyze.LastRecordType == RecordTypeEnumeration.ClassWithMembersAndTypes) return null;
            //
            if (analyze.LastRecordType == RecordTypeEnumeration.BinaryObjectString) return null;


            var record = new ClassWithId();
            record.ObjectId = analyze.Reader.ReadInt32();
            Assert.IsObjectId(record.ObjectId);

            record.MetadataId = analyze.Reader.ReadInt32();
            record.TempId = analyze.Reader.ReadInt32();

            //ClassWithId后面老是会跟个4字节的干扰数据，这里检查下
            var pos = analyze.Reader.BaseStream.Position;
            var value = analyze.Reader.ReadInt32();
            if (value > 0xFF)
            {
                analyze.Reader.BaseStream.Position = pos;
            }

            return record;
        }
    }
}
