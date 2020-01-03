using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The BinaryObjectString record identifies an object as a String object, and contains information about it. The mechanism to serialize a string is described in [MS-NRTP] section 3.1.5.1.11.
    /// </summary>
    class BinaryObjectString
    {
        /// <summary>
        /// A RecordTypeEnumeration value that identifies the record type. The value MUST be 6.
        /// </summary>
        public RecordTypeEnumeration RecordTypeEnum { set; get; }
        /// <summary>
        /// An INT32 value (as specified in [MS-DTYP] section 2.2.22) that uniquely identifies the string instance in the serialization stream. The value MUST be a positive integer. An implementation MAY use any algorithm to generate the unique IDs.<10>
        /// </summary>
        public Int32 ObjectId { set; get; }
        /// <summary>
        /// A LengthPrefixedString value.
        /// </summary>
        public LengthPrefixedString Value { set; get; }
    }
}
