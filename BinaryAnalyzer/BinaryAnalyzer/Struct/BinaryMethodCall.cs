using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The BinaryMethodCall record contains information that is required to perform a Remote Method invocation.
    /// </summary>
    class BinaryMethodCall
    {
        /// <summary>
        /// A RecordTypeEnumeration value that identifies the record type. The value MUST be 21.
        /// </summary>
        public RecordTypeEnumeration RecordTypeEnum { set; get; }
        /// <summary>
        /// A MessageFlags value that indicates whether the arguments and Call Context, Message Properties, Generic Arguments, and Method Signature are present. It also specifies whether the arguments and Call Context are present in this record or in the following MethodCallArray record. For this record type, the field MUST NOT contain the values from the Return and the Exception categories.
        /// </summary>
        public MessageFlags MessageEnum { set; get; }
        /// <summary>
        /// A StringValueWithCode that represents the Remote Method name. The format of the string is as specified in [MS-NRTP] section 2.2.1.1.
        /// </summary>
        public StringValueWithCode MethodName { set; get; }
        /// <summary>
        /// A StringValueWithCode that represents the Server Type name. The format of the string is specified as QualifiedTypeName, as specified in [MS-NRTP] section 2.2.1.2.
        /// </summary>
        public StringValueWithCode TypeName { set; get; }
        /// <summary>
        /// A StringValueWithCode that represents the Logical Call ID. This field is conditional. If the MessageEnum field has the ContextInline bit set, the field MUST be present; otherwise, the field MUST NOT be present. The presence of this field indicates that the Call Context contains a single entry with the Name as "__RemotingData" and the value is an instance of the Remoting Type CallContextRemotingData, as specified in [MS-NRTP] section 2.2.2.16. The value of this field MUST be interpreted as the value of the logicalCallID field in the CallContextRemotingData Class (2).
        /// </summary>
        public StringValueWithCode CallContext { set; get; }
        /// <summary>
        /// An ArrayOfValueWithCode where each item of the Array corresponds to an input argument of the method. The items of the Array MUST be in the same order as the input arguments. This field is conditional. If the MessageEnum field has the ArgsInline bit set, the field MUST be present; otherwise, the field MUST NOT be present.
        /// </summary>
        public ArrayOfValueWithCode Args { set; get; }
    }
}
