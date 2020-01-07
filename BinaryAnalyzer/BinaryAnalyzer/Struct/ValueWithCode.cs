using System;
using System.Collections.Generic;
using System.Text;
using BinaryAnalyzer.RecordTypeHandler;
using BinaryAnalyzer.Interface;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The ValueWithCode structure is used to associate a Primitive Value with an Enum that identifies the Primitive Type of the Primitive Value.
    /// </summary>
    class ValueWithCode : BaseDeserializeObject
    {
        public ValueWithCode(IAnalyze analyze) : base(analyze)
        {
            PrimitiveTypeEnum = (PrimitiveTypeEnumeration)analyze.Reader.ReadByte();
            Value = Common.GetPrimitiveTypeValue(analyze, PrimitiveTypeEnum);
        }

        /// <summary>
        /// A PrimitiveTypeEnumeration value that specifies the type of the data.
        /// </summary>
        public PrimitiveTypeEnumeration PrimitiveTypeEnum { set; get; }
        /// <summary>
        /// A Primitive Value whose Primitive Type is identified by the PrimitiveTypeEnum field. For example, if the value of the PrimitiveTypeEnum field is the PrimitiveTypeEnumeration value INT32, the Value field MUST contain a valid INT32 (as specified in [MS-DTYP] section 2.2.22) instance. The length of the field is determined by the Primitive Type of the Value. This field MUST NOT be present if the value of PrimitiveTypeEnum is Null (17).
        /// </summary>
        public object Value { set; get; }
    }
}
