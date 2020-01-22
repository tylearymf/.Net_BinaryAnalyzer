using BinaryAnalyzer.CustomException;
using BinaryAnalyzer.Misc;
using BinaryAnalyzer.RecordTypeHandler;
using BinaryAnalyzer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using BinaryAnalyzer.Extensions;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// ClassInfo is a common structure used by all the Class (2) records. It has the following structure.
    /// </summary>
    class ClassInfo : BaseDeserializeObject
    {
        public ClassInfo(IAnalyze analyze) : base(analyze)
        {
            ObjectId = analyze.Reader.ReadInt32();
            //暂时这么处理，ObjectId暂时应该不会大于该值
            Assert.IsObjectId(ObjectId);

            Name = new LengthPrefixedString(analyze);
            Assert.IsMemberName(Name.Value);

            MemberCount = analyze.Reader.ReadInt32();
            Assert.IsPositiveIntegerIncludeZero(MemberCount);

            MemberNames = new LengthPrefixedString[MemberCount];
            for (int i = 0; i < MemberCount; i++)
            {
                MemberNames[i] = new LengthPrefixedString(analyze);
                Assert.IsMemberName(MemberNames[i].Value);
            }
        }

        /// <summary>
        /// An INT32 value (as specified in [MS-DTYP] section 2.2.22) that uniquely identifies the object in the serialization stream. An implementation MAY use any algorithm to
        /// </summary>
        public Int32 ObjectId { set; get; }
        /// <summary>
        /// A LengthPrefixedString value that contains the name of the Class (1). The format of the string MUST be as specified in the RemotingTypeName, as specified in [MS-NRTP] section 2.2.1.2.
        /// </summary>
        public LengthPrefixedString Name { set; get; }
        /// <summary>
        /// An INT32 value (as specified in [MS-DTYP] section 2.2.22) that contains the number of Members in the Class (2). The value MUST be 0 or a positive integer.
        /// </summary>
        public Int32 MemberCount { set; get; }
        /// <summary>
        /// A sequence of LengthPrefixedString values that represents the names of the Members in the class (2). The number of items in the sequence MUST be equal to the value specified in the MemberCount field.
        /// </summary>
        public LengthPrefixedString[] MemberNames { set; get; }
    }
}
