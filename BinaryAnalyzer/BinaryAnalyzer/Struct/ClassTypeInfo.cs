using BinaryAnalyzer.RecordTypeHandler;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The ClassTypeInfo identifies a Class (2) by its name and reference to BinaryLibrary record.
    /// </summary>
    class ClassTypeInfo : BaseDeserializeObject
    {
        public ClassTypeInfo(IAnalyze analyze) : base(analyze)
        {
            TypeName = new LengthPrefixedString(analyze);
            LibraryId = analyze.Reader.ReadInt32();
        }

        /// <summary>
        /// A LengthPrefixedString value that contains the name of the Class (2). 
        ///  The format of the string is specified in [MS-NRTP] section 2.2.1.2.
        /// </summary>
        public LengthPrefixedString TypeName { set; get; }
        /// <summary>
        ///  An INT32 (as specified in [MS-DTYP] section 2.2.22) value that represents the ID that identifies the Library name.
        ///  The record that contains this field in a serialization stream MUST be preceded by a BinaryLibrary record that defines the Library name for the ID.
        /// </summary>
        public Int32 LibraryId { set; get; }
    }
}
