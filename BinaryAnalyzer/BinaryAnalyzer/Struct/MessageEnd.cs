using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The MessageEnd record marks the end of the serialization stream.
    /// </summary>
    class MessageEnd : IRecordObject
    {
        /// <summary>
        /// A RecordTypeEnumeration value that identifies the record type. The value MUST be 11.
        /// </summary>
        public RecordTypeEnumeration RecordTypeEnum { set; get; } = RecordTypeEnumeration.MessageEnd;
    }
}
