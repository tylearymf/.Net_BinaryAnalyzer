using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The ObjectNullMultiple record provides a more compact form for multiple consecutive Null records than using individual ObjectNull records. The mechanism to serialize a Null Object is described in [MS-NRTP] section 3.1.5.1.12.
    /// </summary>
    class ObjectNullMultiple
    {
        /// <summary>
        /// A RecordTypeEnumeration value that identifies the record type. The value MUST be 14.
        /// </summary>
        public RecordTypeEnumeration RecordTypeEnum { set; get; }
        /// <summary>
        /// An INT32 value (as specified in [MS-DTYP] section 2.2.22) that is the count of the number of consecutive Null Objects. The value MUST be a positive integer.
        /// </summary>
        public Int32 NullCount { set; get; }
    }
}
