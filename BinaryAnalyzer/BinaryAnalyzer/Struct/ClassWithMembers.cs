using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The ClassWithMembers record is less verbose than ClassWithMembersAndTypes. It does not contain information about the Remoting Type information of the Members. This record can be used when the information is deemed unnecessary because it is known out of band or can be inferred from context.
    /// </summary>
    class ClassWithMembers : IRecordObject
    {
        /// <summary>
        /// A RecordTypeEnumeration value that identifies the record type. Its value MUST be 3.
        /// </summary>
        public RecordTypeEnumeration RecordTypeEnum { set; get; } = RecordTypeEnumeration.ClassWithMembers;
        /// <summary>
        /// A ClassInfo structure that provides information about the name and Members of the Class.
        /// </summary>
        public ClassInfo ClassInfo { set; get; }
        /// <summary>
        /// An INT32 value (as specified in [MS-DTYP] section 2.2.22) that references a BinaryLibrary record by its Library ID. The ID MUST be a positive integer. A BinaryLibrary record with the LibraryId MUST appear earlier in the serialization stream.
        /// </summary>
        public Int32 LibraryId { set; get; }
    }
}
