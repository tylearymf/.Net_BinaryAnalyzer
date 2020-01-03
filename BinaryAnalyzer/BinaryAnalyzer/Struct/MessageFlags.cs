using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The MessageFlags enumeration is used by the BinaryMethodCall (section 2.2.3.1) or BinaryMethodReturn (section 2.2.3.3) records to provide information about the structure of the record. The type of the enumeration is INT32, as specified in [MS-DTYP] section 2.2.22.
    /// The following table is common for both the BinaryMethodCall and BinaryMethodReturn records. The term "Method record" is used in the description when it is applicable to both the records. The term "Call Array record" is used in the description when it is applicable to both MethodCallArray (section 2.2.3.2) and MethodReturnCallArray (section 2.2.3.4).
    /// </summary>
    enum MessageFlags : Int32
    {
        /// <summary>
        /// The record contains no arguments. It is in the Arg category.
        /// </summary>
        NoArgs = 0x00000001,
        /// <summary>
        /// The Arguments Array is in the Args field of the Method record. It is in the Arg category.
        /// </summary>
        ArgsInline = 0x00000002,
        /// <summary>
        /// Each argument is an item in a separate Call Array record. It is in the Arg category.
        /// </summary>
        ArgsIsArray = 0x00000004,
        /// <summary>
        /// The Arguments Array is an item in a separate Call Array record. It is in the Arg category.
        /// </summary>
        ArgsInArray = 0x00000008,
        /// <summary>
        /// The record does not contain a Call Context value. It is in the Context category.
        /// </summary>
        NoContext = 0x00000010,
        /// <summary>
        /// Call Context contains only a Logical Call ID value and is in the CallContext field of the Method record. It is in the Context category.
        /// </summary>
        ContextInline = 0x00000020,
        /// <summary>
        /// CallContext values are contained in an array that is contained in the Call Array record. It is in the Context category.
        /// </summary>
        ContextInArray = 0x00000040,
        /// <summary>
        /// The Method Signature is contained in the Call Array record. It is in the Signature category.
        /// </summary>
        MethodSignatureInArray = 0x00000080,
        /// <summary>
        /// Message Properties is contained in the Call Array record. It is in the Property category.
        /// </summary>
        PropertiesInArray = 0x00000100,
        /// <summary>
        /// The Return Value is a Null object. It is in the Return category.
        /// </summary>
        NoReturnValue = 0x00000200,
        /// <summary>
        /// The method has no Return Value. It is in the Return category.
        /// </summary>
        ReturnValueVoid = 0x00000400,
        /// <summary>
        /// The Return Value is in the ReturnValue field of the MethodReturnCallArray record. It is in the Return category.
        /// </summary>
        ReturnValueInline = 0x00000800,
        /// <summary>
        /// The Return Value is contained in the MethodReturnCallArray record. It is in the Return category.
        /// </summary>
        ReturnValueInArray = 0x00001000,
        /// <summary>
        /// An Exception is contained in the MethodReturnCallArray record. It is in the Exception category.
        /// </summary>
        ExceptionInArray = 0x00002000,
        /// <summary>
        /// The Remote Method is generic and the actual Remoting Types for the Generic Arguments are contained in the Call Array. It is in the Generic category.<2>
        /// </summary>
        GenericMethod = 0x00008000,
    }
}
