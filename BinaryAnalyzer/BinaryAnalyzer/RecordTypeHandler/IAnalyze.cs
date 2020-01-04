using BinaryAnalyzer.Struct;
using System.IO;

namespace BinaryAnalyzer.RecordTypeHandler
{
    interface IAnalyze
    {
        BinaryReader Reader { set; get; }
    }
}
