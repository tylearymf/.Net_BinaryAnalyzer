using System;
using System.Collections.Generic;
using System.Text;
using BinaryAnalyzer.Interface;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The BinaryMethodReturn record contains the information returned by a Remote Method.
    /// </summary>
    class BinaryMethodReturn : IRecordObject
    {
        /// <summary>
        /// A RecordTypeEnumeration value that identifies the record type. The value MUST be 22.
        /// </summary>
        public RecordTypeEnumeration RecordTypeEnum { set; get; } = RecordTypeEnumeration.MethodReturn;
        /// <summary>
        /// A MessageFlags value that indicates whether the Return Value, Arguments, Message Properties, and Call Context are present. The value also specifies whether the Return Value, Arguments, and Call Context are present in this record or the following MethodReturnCallArray record. For this record, the field MUST NOT have the MethodSignatureInArray or GenericMethod bits set.
        /// </summary>
        public MessageFlags MessageEnum { set; get; }
        /// <summary>
        /// A ValueWithCode that contains the Return Value of a Remote Method. If the MessageEnum field has the ReturnValueInline bit set, this field MUST be present; otherwise, this field MUST NOT be present.
        /// </summary>
        public ValueWithCode ReturnValue { set; get; }
        /// <summary>
        /// A StringValueWithCode that represents the Logical Call ID. This field is conditional. If the MessageEnum field has the ContextInline bit set, the field MUST be present; otherwise, the field MUST NOT be present.
        /// </summary>
        public StringValueWithCode CallContext { set; get; }
        /// <summary>
        /// An ArrayOfValueWithCode that contains the Output Arguments of the method. This field is conditional. If the MessageEnum field has the ArgsInline bit set, the field MUST be present; otherwise, the field MUST NOT be present.
        /// </summary>
        public ArrayOfValueWithCode Args { set; get; }
    }
}
