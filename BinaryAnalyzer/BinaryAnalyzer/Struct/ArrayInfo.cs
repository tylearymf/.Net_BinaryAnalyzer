using BinaryAnalyzer.RecordTypeHandler;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The ArrayInfo is a common structure that is used by Array records.
    /// </summary>
    class ArrayInfo : BaseDeserializeObject
    {
        public ArrayInfo(IAnalyze analyze) : base(analyze)
        {
            ObjectId = analyze.Reader.ReadInt32();
            Length = analyze.Reader.ReadInt32();
        }

        /// <summary>
        /// An INT32 value (as specified in [MS-DTYP] section 2.2.22) that uniquely identifies the Array instance in the serialization stream. The ID MUST be a positive integer. An implementation MAY use any algorithm to generate the unique IDs.<7>
        /// </summary>
        public Int32 ObjectId { set; get; }
        /// <summary>
        /// An INT32 value (as specified in [MS-DTYP] section 2.2.22) that specifies the number of items in the Array. The value MUST be 0 or a positive integer.
        /// </summary>
        public Int32 Length { set; get; }
    }
}
