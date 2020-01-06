using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The ArraySinglePrimitive record contains a single-dimensional Array in which all Members are Primitive Value.
    /// This record MUST be followed by a sequence of MemberPrimitiveUnTyped records that contain values whose Primitive Type is specified by the PrimitiveTypeEnum field. The number of records in the sequence MUST match the value specified in the Length field of ArrayInfo.
    /// </summary>
    class ArraySinglePrimitive : IRecordObject
    {
        /// <summary>
        /// A RecordTypeEnumeration value that identifies the record type. The value MUST be 15.
        /// </summary>
        public RecordTypeEnumeration RecordTypeEnum { set; get; } = RecordTypeEnumeration.ArraySinglePrimitive;
        /// <summary>
        /// An ArrayInfo structure that specifies the ID and the length of the Array instance.
        /// </summary>
        public ArrayInfo ArrayInfo { set; get; }
        /// <summary>
        /// A PrimitiveTypeEnumeration value that identifies the Primitive Type of the items of the Array. The value MUST NOT be 17 (Null) or 18 (String).
        /// </summary>
        public PrimitiveTypeEnumeration PrimitiveTypeEnum { set; get; }
        /// <summary>
        /// 如果是PrimitiveTypeEnum是Byte类型，则需要读取ArrayInfo.Length长度的字节流
        /// </summary>
        public object Value { set; get; }
    }
}
