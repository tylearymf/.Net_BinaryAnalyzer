using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The BinaryArrayTypeEnumeration is used to denote the type of an Array. The size of the enumeration is 1 byte. It is used by the Array records
    /// </summary>
    enum BinaryArrayTypeEnumeration : byte
    {
        /// <summary>
        /// A single-dimensional Array.
        /// </summary>
        Single = 0,
        /// <summary>
        /// An Array whose elements are Arrays. The elements of a jagged Array can be of different dimensions and sizes.
        /// </summary>
        Jagged = 1,
        /// <summary>
        /// A multi-dimensional rectangular Array.
        /// </summary>
        Rectangular = 2,
        /// <summary>
        /// A single-dimensional offset.
        /// </summary>
        SingleOffset = 3,
        /// <summary>
        /// A jagged Array where the lower bound index is greater than 0.
        /// </summary>
        JaggedOffset = 4,
        /// <summary>
        /// Multi-dimensional Arrays where the lower bound index of at least one of the dimensions is greater than 0.
        /// </summary>
        RectangularOffset = 5,
    }
}
