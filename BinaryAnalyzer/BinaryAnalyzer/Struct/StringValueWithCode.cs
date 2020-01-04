using System;
using System.Collections.Generic;
using System.Text;
using BinaryAnalyzer.RecordTypeHandler;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The StringValueWithCode structure is a ValueWithCode where PrimitiveTypeEnumeration is String (18).
    /// </summary>
    class StringValueWithCode : BaseDeserializeObject
    {
        public StringValueWithCode(IAnalyze analyze) : base(analyze)
        {
            StringValue = new LengthPrefixedString(analyze);
        }

        /// <summary>
        /// A PrimitiveTypeEnumeration value that specifies the Primitive Type of the data. The value MUST be 18 (String).
        /// </summary>
        public PrimitiveTypeEnumeration PrimitiveTypeEnum { set; get; } = PrimitiveTypeEnumeration.String;
        /// <summary>
        /// A LengthPrefixedString that contains the string value.
        /// </summary>
        public LengthPrefixedString StringValue { set; get; }
    }
}
