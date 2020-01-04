using BinaryAnalyzer.RecordTypeHandler;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// he SystemClassWithMembers record is less verbose than ClassWithMembersAndTypes. It does not contain a LibraryId or the information about the Remoting Types of the Members. This record
    /// implicitly specifies that the Class is in the System Library. This record can be used when the information is deemed unnecessary because it is known out of band or can be inferred from context.
    /// </summary>
    class SystemClassWithMembers : IRecordObject
    {
        /// <summary>
        /// A RecordTypeEnumeration value that identifies the record type. Its value MUST be 2.
        /// </summary>
        public RecordTypeEnumeration RecordTypeEnum { set; get; } = RecordTypeEnumeration.SystemClassWithMembers;
        /// <summary>
        /// A ClassInfo structure that provides information about the name and Members of the Class.
        /// </summary>
        public ClassInfo ClassInfo { set; get; }
    }
}
