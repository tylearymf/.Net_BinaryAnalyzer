using System;
using System.Collections.Generic;
using System.Text;
using BinaryAnalyzer.RecordTypeHandler;

namespace BinaryAnalyzer.Struct
{
    static class Common
    {
        static public object GetBinaryTypeValue(IAnalyze analyze, BinaryTypeEnumeration binaryType)
        {
            object value = null;
            switch (binaryType)
            {
                case BinaryTypeEnumeration.Primitive:
                    var temp = (PrimitiveTypeEnumeration)analyze.Reader.ReadByte();
                    value = temp;

                    if (temp == PrimitiveTypeEnumeration.String)
                    {
                        throw new Exception();
                    }
                    break;
                case BinaryTypeEnumeration.SystemClass:
                    //可能有问题
                    value = new LengthPrefixedString(analyze);
                    break;
                case BinaryTypeEnumeration.Class:
                    value = new ClassTypeInfo(analyze);
                    break;
                case BinaryTypeEnumeration.PrimitiveArray:
                    throw new NotImplementedException();
            }

            return value;
        }

        static public object GetPrimitiveTypeValue(IAnalyze analyze, PrimitiveTypeEnumeration primitiveType)
        {
            object value = null;
            switch (primitiveType)
            {
                case PrimitiveTypeEnumeration.Boolean:
                    value = analyze.Reader.ReadBoolean();
                    break;
                case PrimitiveTypeEnumeration.Byte:
                    value = analyze.Reader.ReadByte();
                    break;
                case PrimitiveTypeEnumeration.Char:
                    value = analyze.Reader.ReadChar();
                    break;
                case PrimitiveTypeEnumeration.Decimal:
                    value = analyze.Reader.ReadDecimal();
                    break;
                case PrimitiveTypeEnumeration.Double:
                    value = analyze.Reader.ReadDouble();
                    break;
                case PrimitiveTypeEnumeration.Int16:
                    value = analyze.Reader.ReadInt16();
                    break;
                case PrimitiveTypeEnumeration.Int32:
                    value = analyze.Reader.ReadInt32();
                    break;
                case PrimitiveTypeEnumeration.Int64:
                    value = analyze.Reader.ReadInt64();
                    break;
                case PrimitiveTypeEnumeration.SByte:
                    value = analyze.Reader.ReadSByte();
                    break;
                case PrimitiveTypeEnumeration.Single:
                    value = analyze.Reader.ReadSingle();
                    break;
                case PrimitiveTypeEnumeration.TimeSpan:
                    value = new TimeSpan(analyze.Reader.ReadInt64());
                    break;
                case PrimitiveTypeEnumeration.DateTime:
                    value = DateTime.FromBinary(analyze.Reader.ReadInt64());
                    break;
                case PrimitiveTypeEnumeration.UInt16:
                    value = analyze.Reader.ReadUInt16();
                    break;
                case PrimitiveTypeEnumeration.UInt32:
                    value = analyze.Reader.ReadUInt32();
                    break;
                case PrimitiveTypeEnumeration.UInt64:
                    value = analyze.Reader.ReadUInt64();
                    break;
                case PrimitiveTypeEnumeration.String:
                    value = analyze.Reader.ReadString();
                    break;
            }

            return value;
        }
    }
}
