using System;
using System.Collections.Generic;
using System.Text;
using BinaryAnalyzer.Interface;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The SerializationHeaderRecord record MUST be the first record in a binary serialization. This record has the major and minor version of the format and the IDs of the top object and the headers.
    /// </summary>
    class SerializationHeaderRecord : IRecordObject
    {
        /// <summary>
        /// A RecordTypeEnumeration value that identifies the record type. The value MUST be 0.
        /// </summary>
        public RecordTypeEnumeration RecordTypeEnum { set; get; } = RecordTypeEnumeration.SerializedStreamHeader;
        /// <summary>
        /// An INT32 value (as specified in [MS-DTYP] section 2.2.22) that identifies the root of the graph of nodes. The value of the field is set as follows:
        /// ·If a BinaryMethodCall record is present in the serialization stream and if there is no MethodCallArray record following it, the value of this field MUST be 0; if a MethodCallArray record follows the BinaryMethodCall record, the value of this field MUST contain the ObjectId of the MethodCallArray.
        /// ·If a BinaryMethodReturn record is present in the serialization stream and if there is no MethodReturnCallArray record following it, the value of this field MUST be 0; if a MethodReturnCallArray record follows the BinaryMethodReturn record, the value of this field MUST contain the ObjectId of the MethodReturnCallArray.
        /// ·If neither the BinaryMethodCall nor BinaryMethodReturn record is present in the serialization stream, the value of this field MUST contain the ObjectId of a Class, Array, or BinaryObjectString record contained in the serialization stream.
        /// </summary>
        public Int32 RootId { set; get; }
        /// <summary>
        /// An INT32 value (as specified in [MS-DTYP] section 2.2.22) that identifies the Array that contains the header objects. The value of the field is set as follows:
        /// ·If a BinaryMethodCall record is present in the serialization stream and if there is no MethodCallArray record following it, the value of this field MUST be 0; if a MethodCallArray record follows the BinaryMethodCall record, the value of this field MUST be -1.
        /// ·If a BinaryMethodReturn record is present in the serialization stream and if there is no MethodReturnCallArray record following it, the value of this field MUST be 0; if a MethodReturnCallArray record follows the BinaryMethodReturn record, the value of this field MUST be -1.
        /// ·If neither the BinaryMethodCall nor BinaryMethodReturn record is present in the serialization stream, the value of this field MUST contain the ObjectId of a Class, Array , or BinaryObjectString record that is contained in the serialization stream.
        /// The field MUST be ignored on read.
        /// </summary>
        public Int32 HeaderId { set; get; }
        /// <summary>
        /// An INT32 value (as specified in [MS-DTYP] section 2.2.22) that identifies the major version of the format. The value of this field MUST be 1.
        /// </summary>
        public Int32 MajorVersion { set; get; }
        /// <summary>
        /// An INT32 value (as specified in [MS-DTYP] section 2.2.22) that identifies the minor version of the protocol. The value of this field MUST be 0.
        /// </summary>
        public Int32 MinorVersion { set; get; }
    }
}
