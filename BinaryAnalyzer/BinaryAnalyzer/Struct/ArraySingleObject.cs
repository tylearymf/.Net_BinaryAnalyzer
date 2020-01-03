using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The ArraySingleObject record contains a single-dimensional Array in which each Member record MAY contain any Data Value.
    /// </summary>
    class ArraySingleObject
    {
        /// <summary>
        /// A RecordTypeEnumeration value that identifies the record type. The value MUST be 16.
        /// </summary>
        public RecordTypeEnumeration RecordTypeEnum { set; get; }
        /// <summary>
        /// An ArrayInfo structure that specifies the ID and the length of the Array instance.
        /// </summary>
        public ArrayInfo ArrayInfo { set; get; }
    }
}
