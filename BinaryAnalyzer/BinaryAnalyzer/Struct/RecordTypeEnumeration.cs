using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// This enumeration identifies the type of the record. Each record (except for MemberPrimitiveUnTyped) starts with a record type enumeration. The size of the enumeration is one BYTE.
    /// </summary>
    enum RecordTypeEnumeration : byte
    {
        /// <summary>
        /// Identifies the SerializationHeaderRecord.
        /// <seealso cref="Struct.SerializationHeaderRecord"/>
        /// </summary>
        SerializedStreamHeader = 0,
        /// <summary>
        /// Identifies a ClassWithId record.
        /// <seealso cref="Struct.ClassWithId"/>
        /// </summary>
        ClassWithId = 1,
        /// <summary>
        /// Identifies a SystemClassWithMembers record.
        /// <seealso cref="Struct.SystemClassWithMembers"/>
        /// </summary>
        SystemClassWithMembers = 2,
        /// <summary>
        /// Identifies a ClassWithMembers record.
        /// <seealso cref="Struct.ClassWithMembers"/>
        /// </summary>
        ClassWithMembers = 3,
        /// <summary>
        /// Identifies a SystemClassWithMembersAndTypes record.
        /// <seealso cref="Struct.SystemClassWithMembersAndTypes"/>
        /// </summary>
        SystemClassWithMembersAndTypes = 4,
        /// <summary>
        /// Identifies a ClassWithMembersAndTypes record.
        /// <seealso cref="Struct.ClassWithMembersAndTypes"/>
        /// </summary>
        ClassWithMembersAndTypes = 5,
        /// <summary>
        /// Identifies a BinaryObjectString record.
        /// <seealso cref="Struct.BinaryObjectString"/>
        /// </summary>
        BinaryObjectString = 6,
        /// <summary>
        /// Identifies a BinaryArray record.
        /// <seealso cref="Struct.BinaryArray"/>
        /// </summary>
        BinaryArray = 7,
        /// <summary>
        /// Identifies a MemberPrimitiveTyped record.
        /// <seealso cref="Struct.MemberPrimitiveTyped"/>
        /// </summary>
        MemberPrimitiveTyped = 8,
        /// <summary>
        /// Identifies a MemberReference record.
        /// <seealso cref="Struct.MemberReference"/>
        /// </summary>
        MemberReference = 9,
        /// <summary>
        /// Identifies an ObjectNull record.
        /// <seealso cref="Struct.ObjectNull"/>
        /// </summary>
        ObjectNull = 10,
        /// <summary>
        /// Identifies a MessageEnd record.
        /// <seealso cref="Struct.MessageEnd"/>
        /// </summary>
        MessageEnd = 11,
        /// <summary>
        /// Identifies a BinaryLibrary record.
        /// <seealso cref="Struct.BinaryLibrary"/>
        /// </summary>
        BinaryLibrary = 12,
        /// <summary>
        /// Identifies an ObjectNullMultiple256 record.
        /// <seealso cref="Struct.ObjectNullMultiple256"/>
        /// </summary>
        ObjectNullMultiple256 = 13,
        /// <summary>
        /// Identifies an ObjectNullMultiple record
        /// <seealso cref="Struct.ObjectNullMultiple"/>
        /// </summary>
        ObjectNullMultiple = 14,
        /// <summary>
        /// Identifies an ArraySinglePrimitive.
        /// <seealso cref="Struct.ArraySinglePrimitive"/>
        /// </summary>
        ArraySinglePrimitive = 15,
        /// <summary>
        /// Identifies an ArraySingleObject record.
        /// <seealso cref="Struct.ArraySingleObject"/>
        /// </summary>
        ArraySingleObject = 16,
        /// <summary>
        /// Identifies an ArraySingleString record.
        /// <seealso cref="Struct.ArraySingleString"/>
        /// </summary>
        ArraySingleString = 17,
        /// <summary>
        /// Identifies a BinaryMethodCall record.
        /// <seealso cref="Struct.BinaryMethodCall"/>
        /// </summary>
        MethodCall = 21,
        /// <summary>
        /// Identifies a BinaryMethodReturn record.
        /// <seealso cref="Struct.BinaryMethodReturn"/>
        /// </summary>
        MethodReturn = 22,
    }
}
