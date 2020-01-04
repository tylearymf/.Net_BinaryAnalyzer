using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The MemberPrimitiveTyped record contains a Primitive Type value other than String. The mechanism to serialize a Primitive Value is described in [MS-NRTP] section 3.1.5.1.8.
    /// </summary>
    class MemberPrimitiveTyped : IRecordObject
    {
        /// <summary>
        /// A RecordTypeEnumeration value that identifies the record type. The value MUST be 8.
        /// </summary>
        public RecordTypeEnumeration RecordTypeEnum { set; get; } = RecordTypeEnumeration.MemberPrimitiveTyped;
        /// <summary>
        /// A PrimitiveTypeEnumeration value that specifies the Primitive Type of data that is being transmitted. This field MUST NOT contain a value of 17 (Null) or 18 (String).
        /// </summary>
        public PrimitiveTypeEnumeration PrimitiveTypeEnum { set; get; }
        /// <summary>
        /// The value whose type is inferred from the PrimitiveTypeEnum field as specified in the table in section 2.1.2.3.
        /// </summary>
        public object Value { set; get; }
    }
}
