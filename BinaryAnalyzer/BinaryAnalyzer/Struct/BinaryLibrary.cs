using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The BinaryLibrary record associates an INT32 ID (as specified in [MS-DTYP] section 2.2.22) with a Library name. This allows other records to reference the Library name by using the ID. This approach reduces the wire size when there are multiple records that reference the same Library name.
    /// </summary>
    class BinaryLibrary
    {
        /// <summary>
        /// A RecordTypeEnumeration value that identifies the record type. The value MUST be 12.
        /// </summary>
        public RecordTypeEnumeration RecordTypeEnum { set; get; }
        /// <summary>
        /// An INT32 value (as specified in [MS-DTYP] section 2.2.22) that uniquely identifies the Library name in the serialization stream. The value MUST be a positive integer. An implementation MAY use any algorithm to generate the unique IDs.<11>
        /// </summary>
        public Int32 LibraryId { set; get; }
        /// <summary>
        /// A LengthPrefixedString value that represents the Library name. The format of the string is specified in [MS-NRTP] section 2.2.1.3.
        /// </summary>
        public LengthPrefixedString LibraryName { set; get; }
    }
}
