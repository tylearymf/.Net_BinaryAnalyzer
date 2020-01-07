using System;
using System.Collections.Generic;
using System.Text;
using BinaryAnalyzer.Interface;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The SystemClassWithMembersAndTypes record is less verbose than ClassWithMembersAndTypes. It does not contain a LibraryId. This record implicitly specifies that the Class is in the System Library.
    /// </summary>
    class SystemClassWithMembersAndTypes : IRecordObject
    {
        /// <summary>
        /// A RecordTypeEnumeration value that identifies the record type. Its value MUST be 4.
        /// </summary>
        public RecordTypeEnumeration RecordTypeEnum { set; get; } = RecordTypeEnumeration.SystemClassWithMembersAndTypes;
        /// <summary>
        /// A ClassInfo structure that provides information about the name and Members of the Class.
        /// </summary>
        public ClassInfo ClassInfo { set; get; }
        /// <summary>
        /// A MemberTypeInfo structure that provides information about the Remoting Type of the Members.
        /// </summary>
        public MemberTypeInfo MemberTypeInfo { set; get; }
    }
}
