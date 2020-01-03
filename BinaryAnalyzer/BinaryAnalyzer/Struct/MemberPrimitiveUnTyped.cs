using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The MemberPrimitiveUnTyped record is the most compact record to represent a Primitive Type value. This type of record does not have a RecordTypeEnum to indicate the record type.
    /// The record MUST be used when a Class Member or Array item is a Primitive Type. Because the containing Class or Array record specifies the Primitive Type of each Member,
    /// the Primitive Type is not respecified along with the value. Also, the Primitive Values cannot be referenced by any other record;
    /// therefore it does not require an ObjectId. This record has no field besides the value. The mechanism to serialize a Primitive Value is described in [MS-NRTP] section 3.1.5.1.8.
    /// </summary>
    class MemberPrimitiveUnTyped
    {
        /// <summary>
        /// A Primitive Type value other than String.
        /// </summary>
        public object Value { set; get; }
    }
}
