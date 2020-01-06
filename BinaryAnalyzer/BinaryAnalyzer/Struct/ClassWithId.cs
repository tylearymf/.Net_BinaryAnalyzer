using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The ClassWithId record is the most compact. It has no metadata. It refers to metadata defined in SystemClassWithMembers, SystemClassWithMembersAndTypes, ClassWithMembers, or ClassWithMembersAndTypes record.
    /// </summary>
    class ClassWithId : IRecordObject
    {
        /// <summary>
        /// A RecordTypeEnumeration value that identifies the record type. The value MUST be 1.
        /// </summary>
        public RecordTypeEnumeration RecordTypeEnum { set; get; } = RecordTypeEnumeration.ClassWithId;
        /// <summary>
        /// An INT32 value (as specified in [MS-DTYP] section 2.2.22) that uniquely identifies the object in the serialization stream.
        /// </summary>
        public Int32 ObjectId { set; get; }
        /// <summary>
        /// An INT32 value (as specified in [MS-DTYP] section 2.2.22) that references one of the other Class records by its ObjectId. A SystemClassWithMembers, SystemClassWithMembersAndTypes, ClassWithMembers, or ClassWithMembersAndTypes record with the value of this field in its ObjectId field MUST appear earlier in the serialization stream.
        /// </summary>
        public Int32 MetadataId { set; get; }
        /// <summary>
        /// 貌似这里有个Int32的字段
        /// </summary>
        public Int32 TempId { set; get; }
    }
}
