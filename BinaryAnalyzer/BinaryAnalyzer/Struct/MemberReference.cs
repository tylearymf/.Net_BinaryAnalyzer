using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The MemberReference record contains a reference to another record that contains the actual value.
    /// The record is used to serialize values of a Class Member and Array items. 
    /// The mechanism to serialize a Class instance is described in [MS-NRTP] section 3.1.5.1.6.
    /// The mechanism to serialize an Array instance is described in [MS-NRTP] section 3.1.5.1.7.
    /// </summary>
    class MemberReference
    {
        /// <summary>
        /// A RecordTypeEnumeration value that identifies the record type. The value MUST be 9.
        /// </summary>
        public RecordTypeEnumeration RecordTypeEnum { set; get; }
        /// <summary>
        /// An INT32 value (as specified in [MS-DTYP] section 2.2.22) that is an ID of an object defined in another record.
        /// ·The value MUST be a positive integer.
        /// ·A Class, Array, or BinaryObjectString record MUST exist in the serialization stream with the value as its ObjectId.
        ///   Unlike other ID references, there is no restriction on where the record that defines the ID appears in the serialization stream; that is, it MAY appear after the referencing record.<9>
        /// </summary>
        public Int32 IdRef { set; get; }
    }
}
