using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The MemberTypeInfo is a common structure that contains type information for Class (2) Members. It has the following structure.
    /// </summary>
    class MemberTypeInfo
    {
        /// <summary>
        /// A sequence of BinaryTypeEnumeration values that represents the Member Types that are being transferred. The Array MUST:
        /// ·Have the same number of items as the MemberCount field of the ClassInfo structure.
        /// ·Be ordered such that the BinaryTypeEnumeration corresponds to the Member name in the MemberNames field of the ClassInfo structure.
        /// </summary>
        public BinaryTypeEnumeration[] BinaryTypeEnums { set; get; }
        /// <summary>
        /// A sequence of additional information about a Remoting Type. For every value of the BinaryTypeEnum in the BinaryTypeEnums field that is a Primitive, SystemClass, Class (2), or PrimitiveArray, the AdditionalInfos field contains additional information about the Remoting Type. For the BinaryTypeEnum value of Primitive and PrimitiveArray, this field specifies the actual Primitive Type that uses the PrimitiveTypeEnum. For the BinaryTypeEnum value of SystemClass, this field specifies the name of the class (2). For the BinaryTypeEnum value of Class (2), this field specifies the name of the Class (2) and the Library ID. The following table enumerates additional information required for each BinaryType enumeration.
        /// Primitive       PrimitiveTypeEnumeration
        /// String          None
        /// Object          None
        /// SystemClass     String (Class (1) name as specified in [MS-NRTP] section 2.2.1.2)
        /// Class           ClassTypeInfo
        /// ObjectArray     None
        /// StringArray     None
        /// PrimitiveArray  PrimitiveTypeEnumeration
        /// ·The AdditionalInfos sequence MUST NOT contain any item for the BinaryTypeEnum values of String, Object, ObjectArray, or StringArray.
        /// ·The AdditionalInfos items MUST be in the same order as the corresponding BinaryTypeEnum items in the BinaryTypeEnums field.
        /// ·When the BinaryTypeEnum value is Primitive, the PrimitiveTypeEnumeration value in AdditionalInfo MUST NOT be Null (17) or String (18).
        /// </summary>
        public object AdditionalInfos { set; get; }
    }
}
