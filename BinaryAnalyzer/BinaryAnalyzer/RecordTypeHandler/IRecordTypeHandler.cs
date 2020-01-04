using BinaryAnalyzer.Struct;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BinaryAnalyzer.RecordTypeHandler
{
    interface IRecordTypeHandler
    {
        IRecordObject Handle(IAnalyze analyze);
    }
}
