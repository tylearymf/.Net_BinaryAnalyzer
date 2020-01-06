using BinaryAnalyzer.Struct;
using System.IO;

namespace BinaryAnalyzer.RecordTypeHandler
{
    interface IAnalyze
    {
        RecordTypeEnumeration LastRecordType { set; get; }
        IRecordObject LastObject { set; get; }
        BinaryReader Reader { set; get; }
    }
}
