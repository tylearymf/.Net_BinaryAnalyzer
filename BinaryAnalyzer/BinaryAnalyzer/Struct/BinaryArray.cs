using System;
using System.Collections.Generic;
using System.Text;
using BinaryAnalyzer.Interface;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// BinaryArray is the most general form of Array records. The record is more verbose than the other Array records.
    /// </summary>
    class BinaryArray : IRecordObject
    {
        /// <summary>
        /// A RecordTypeEnumeration value that identifies the record type. Its value MUST be 7.
        /// </summary>
        public RecordTypeEnumeration RecordTypeEnum { set; get; } = RecordTypeEnumeration.BinaryArray;
        /// <summary>
        /// An INT32 value (as specified in [MS-DTYP] section 2.2.22) that uniquely identifies the Array in the serialization stream. The value MUST be a positive integer. An implementation MAY use any algorithm to generate the unique IDs.<8>
        /// </summary>
        public Int32 ObjectId { set; get; }
        /// <summary>
        /// A BinaryArrayTypeEnumeration value that identifies the type of the Array.
        /// </summary>
        public BinaryArrayTypeEnumeration BinaryArrayTypeEnum { set; get; }
        /// <summary>
        /// An INT32 value (as specified in [MS-DTYP] section 2.2.22) that specifies the rank (number of dimensions) of the Array. The value MUST be 0 or a positive integer.
        /// </summary>
        public Int32 Rank { set; get; }
        /// <summary>
        /// A sequence of INT32 values (as specified in [MS-DTYP] section 2.2.22) that specifies the length of each of the dimensions of the Array. The number of values MUST be equal to the value specified in the Rank field. Each value of the sequence MUST be 0 or a positive integer.
        /// </summary>
        public Int32[] Lengths { set; get; }
        /// <summary>
        /// A sequence of INT32 values (as specified in [MS-DTYP] section 2.2.22) that specifies the lower bound (first index) of each of the dimensions of the Array. The number of values MUST be equal to the value specified in the Rank field. If the value of the BinaryArrayTypeEnum field is SingleOffset, JaggedOffset, or RectangularOffset, this field MUST be present in the serialization stream; otherwise, this field MUST NOT be present in the serialization stream.
        /// </summary>
        public Int32[] LowerBounds { set; get; }
        /// <summary>
        /// A BinaryTypeEnum value that identifies the Remoting Type of the Array item.
        /// </summary>
        public BinaryTypeEnumeration TypeEnum { set; get; }
        /// <summary>
        /// Information about the Remoting Type of the Array item in addition to the information provided in the TypeEnum field. For the BinaryTypeEnum values of Primitive, SystemClass, Class, or PrimitiveArray, this field contains additional information about the 
        /// Remoting Type. For the BinaryTypeEnum value of Primitive and PrimitiveArray, this field specifies the actual Primitive Type that uses the PrimitiveTypeEnum. For the BinaryTypeEnum value of
        /// SystemClass, this field specifies the name of the Class. For the BinaryTypeEnum value of Class, this field specifies the name of the Class and the Library ID. The following table enumerates additional information that is required for each BinaryType enumeration.
        /// 
        /// Primitive       PrimitiveTypeEnum
        /// Object          None
        /// String          None
        /// SystemClass     String (Class name as specified in [MS-NRTP] section 2.2.1.2)
        /// Class           ClassTypeInfo
        /// ObjectArray     None
        /// StringArray     None
        /// PrimitiveArray  PrimitiveTypeEnum
        /// 
        /// If the BinaryTypeEnum value of the TypeEnum field is Object, String, ObjectArray, or StringArray, this field MUST NOT be present in the serialization stream.
        /// If the BinaryTypeEnum value is Primitive, the PrimitiveTypeEnumeration value in AdditionalTypeInfo MUST NOT be Null (17) or String (18).
        /// </summary>
        public object AdditionalTypeInfo { set; get; }
    }
}
