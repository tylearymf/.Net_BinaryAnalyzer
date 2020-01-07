using System;
using System.Collections.Generic;
using System.Text;
using BinaryAnalyzer.Interface;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The ObjectNull record contains a Null Object. The mechanism to serialize a Null Object is described in [MS-NRTP] section 3.1.5.1.12.
    /// </summary>
    class ObjectNull : IRecordObject
    {
        /// <summary>
        /// A RecordTypeEnumeration value that identifies the record type. The value MUST be 10.
        /// </summary>
        public RecordTypeEnumeration RecordTypeEnum { set; get; } = RecordTypeEnumeration.ObjectNull;
    }
}
