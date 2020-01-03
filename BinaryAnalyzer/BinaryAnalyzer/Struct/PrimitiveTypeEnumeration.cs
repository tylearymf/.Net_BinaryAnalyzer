using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The PrimitiveTypeEnumeration identifies a Primitive Type value. The size of the enumeration is a BYTE.
    /// </summary>
    enum PrimitiveTypeEnumeration : byte
    {
        /// <summary>
        /// Identifies a BOOLEAN as specified in [MS-DTYP] section 2.2.4.
        /// </summary>
        Boolean = 1,
        /// <summary>
        /// Identifies a BYTE as specified in [MS-DTYP] section 2.2.6.
        /// </summary>
        Byte = 2,
        /// <summary>
        /// Identifies a Char (section 2.1.1.1) type.
        /// </summary>
        Char = 3,
        /// <summary>
        /// The value is not used in the protocol.
        /// </summary>
        None = 4,
        /// <summary>
        /// Identifies a Decimal (section 2.1.1.7).
        /// </summary>
        Decimal = 5,
        /// <summary>
        /// Identifies a Double (section 2.1.1.2).
        /// </summary>
        Double = 6,
        /// <summary>
        /// Identifies an INT16 as specified in [MS-DTYP] section 2.2.21.
        /// </summary>
        Int16 = 7,
        /// <summary>
        /// Identifies an INT32 as specified in [MS-DTYP] section 2.2.22.
        /// </summary>
        Int32 = 8,
        /// <summary>
        /// Identifies an INT64 as specified in [MS-DTYP] section 2.2.23.
        /// </summary>
        Int64 = 9,
        /// <summary>
        /// Identifies an INT8 as specified in [MS-DTYP] section 2.2.20.
        /// </summary>
        SByte = 10,
        /// <summary>
        /// Identifies a Single (section 2.1.1.3).
        /// </summary>
        Single = 11,
        /// <summary>
        /// Identifies a TimeSpan (section 2.1.1.4).
        /// </summary>
        TimeSpan = 12,
        /// <summary>
        /// Identifies a DateTime (section 2.1.1.5).
        /// </summary>
        DateTime = 13,
        /// <summary>
        /// Identifies a UINT16 as specified in [MS-DTYP] section 2.2.48.
        /// </summary>
        UInt16 = 14,
        /// <summary>
        /// Identifies a UINT32 as specified in [MS-DTYP] section 2.2.49.
        /// </summary>
        UInt32 = 15,
        /// <summary>
        /// Identifies a UINT64 as specified in [MS-DTYP] section 2.2.50.
        /// </summary>
        UInt64 = 16,
        /// <summary>
        /// Identifies a Null Object.
        /// </summary>
        Null = 17,
        /// <summary>
        /// Identifies a LengthPrefixedString (section 2.1.1.6) value.
        /// </summary>
        String = 18,
    }
}
