using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The ArrayOfValueWithCode structure contains a list of ValueWithCode records. The list is prefixed with the length of the Array.
    /// </summary>
    class ArrayOfValueWithCode
    {
        /// <summary>
        /// An INT32 value (as specified in [MS-DTYP] section 2.2.22) that indicates the number of items in the Array. The value can range from 0 to 2147483647 (2^31) inclusive.
        /// </summary>
        public Int32 Length { set; get; }
        /// <summary>
        /// A sequence of ValueWithCode records. The number of items in the sequence MUST be equal to the value specified in the Length field.
        /// </summary>
        public ValueWithCode[] ListOfValueWithCode { set; get; }
    }
}
