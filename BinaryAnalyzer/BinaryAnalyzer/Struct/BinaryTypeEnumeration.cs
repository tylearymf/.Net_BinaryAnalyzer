using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The BinaryTypeEnumeration identifies the Remoting Type of a Class (2) Member or an Array item. The size of the enumeration is a BYTE.
    /// </summary>
    enum BinaryTypeEnumeration : byte
    {
        /// <summary>
        /// The Remoting Type is defined in PrimitiveTypeEnumeration and the Remoting Type is not a string.
        /// </summary>
        Primitive = 0,
        /// <summary>
        /// The Remoting Type is a LengthPrefixedString.
        /// </summary>
        String = 1,
        /// <summary>
        /// The Remoting Type is System.Object.
        /// </summary>
        Object = 2,
        /// <summary>
        /// The Remoting Type is one of the following:
        /// ·A Class (2) in the System Library
        /// ·An Array whose Ultimate Array Item Type is a Class (2) in the System Library
        /// ·An Array whose Ultimate Array Item Type is System.Object, String, or a Primitive Type but does not meet the definition of ObjectArray, StringArray, or PrimitiveArray.
        /// </summary>
        SystemClass = 3,
        /// <summary>
        /// The Remoting Type is a Class (2) or an Array whose Ultimate Array Item Type is a Class (2) that is not in the System Library.
        /// </summary>
        Class = 4,
        /// <summary>
        /// The Remoting Type is a single-dimensional Array of System.Object with a lower bound of 0.
        /// </summary>
        ObjectArray = 5,
        /// <summary>
        /// The Remoting Type is a single-dimensional Array of String with a lower bound of 0.
        /// </summary>
        StringArray = 6,
        /// <summary>
        /// The Remoting Type is a single-dimensional Array of a Primitive Type with a lower bound of 0.
        /// </summary>
        PrimitiveArray = 7,
    }
}
