using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.Struct;
using System;
using System.IO;

namespace BinaryAnalyzer.RecordTypeHandler
{
    [Handler(Struct.RecordTypeEnumeration.SerializedStreamHeader)]
    class Handler_SerializedStreamHeader : IRecordTypeHandler
    {
        IRecordObject IRecordTypeHandler.Handle(IAnalyze analyze)
        {
            //EOF
			//感觉是无意义的数据
            while (analyze.Reader.BaseStream.Position < analyze.Reader.BaseStream.Length)
            {
                if (analyze.Reader.BaseStream.Position == 1)
                {
                    break;
                }
                else
                {
                    return null;
                }
            }

            var record = new SerializationHeaderRecord();
            record.RootId = analyze.Reader.ReadInt32();
            record.HeaderId = analyze.Reader.ReadInt32();
            record.MajorVersion = analyze.Reader.ReadInt32();
            record.MinorVersion = analyze.Reader.ReadInt32();

            return record;
        }
    }
}
