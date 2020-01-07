using System;
using System.Collections.Generic;
using System.Text;
using BinaryAnalyzer.Interface;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The ClassWithMembersAndTypes record is the most verbose of the Class records. It contains metadata about Members, including the names and Remoting Types of the Members. It also contains a Library ID that references the Library Name of the Class.
    /// </summary>
    class ClassWithMembersAndTypes : IRecordObject
    {
        /// <summary>
        /// RecordTypeEnumeration value that identifies the record type. Its value MUST be 5.
        /// </summary>
        public RecordTypeEnumeration RecordTypeEnum { set; get; } = RecordTypeEnumeration.ClassWithMembersAndTypes;
        /// <summary>
        /// A ClassInfo structure that provides information about the name and Members of the Class.
        /// </summary>
        public ClassInfo ClassInfo { set; get; }
        /// <summary>
        /// A MemberTypeInfo structure that provides information about the Remoting Types of the Members.
        /// </summary>
        public MemberTypeInfo MemberTypeInfo { set; get; }
        /// <summary>
        /// An INT32 value (as specified in [MS-DTYP] section 2.2.22) that references a BinaryLibrary record by its Library ID. A BinaryLibrary record with the LibraryId MUST appear earlier in the serialization stream.
        /// </summary>
        public Int32 LibraryId { set; get; }
    }
}
