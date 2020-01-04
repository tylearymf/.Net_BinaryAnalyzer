using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The ArraySingleString record contains a single-dimensional Array whose items are String values.
    /// </summary>
    class ArraySingleString : IRecordObject
    {
        /// <summary>
        /// A RecordTypeEnumeration value that identifies the record type. The value MUST be 17.
        /// </summary>
        public RecordTypeEnumeration RecordTypeEnum { set; get; } = RecordTypeEnumeration.ArraySingleString;
        /// <summary>
        /// An ArrayInfo structure that specifies the ID and the length of the Array instance.
        /// </summary>
        public ArrayInfo ArrayInfo { set; get; }
    }
}
