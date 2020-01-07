using System;
using System.Collections.Generic;
using System.Text;
using BinaryAnalyzer.RecordTypeHandler;
using BinaryAnalyzer.Interface;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The ObjectNullMultiple256 record provides the most compact form for multiple, consecutive Null records when the count of Null records is less than 256. The mechanism to serialize a Null Object is described in [MS-NRTP] section 3.1.5.1.12.
    /// </summary>
    class ObjectNullMultiple256 : IRecordObject
    {
        /// <summary>
        /// A RecordTypeEnumeration value that identifies the record type. The value MUST be 13.
        /// </summary>
        public RecordTypeEnumeration RecordTypeEnum { set; get; } = RecordTypeEnumeration.ObjectNullMultiple256;
        /// <summary>
        /// A BYTE value (as specified in [MS-DTYP] section 2.2.6) that is the count of the number of consecutive Null objects. The value MUST be in the range of 0 to 255, inclusive.
        /// </summary>
        public byte NullCount { set; get; }
    }
}
