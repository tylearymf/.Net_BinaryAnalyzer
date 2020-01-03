using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    class ClassTypeInfo
    {
        public LengthPrefixedString TypeName { set; get; }

        public Int32 LibraryId { set; get; }
    }
}
