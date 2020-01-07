using BinaryAnalyzer.Struct;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BinaryAnalyzer.Interface
{
    interface IRecordTypeHandler
    {
        IRecordObject Handle(IAnalyze analyze);
    }
}
