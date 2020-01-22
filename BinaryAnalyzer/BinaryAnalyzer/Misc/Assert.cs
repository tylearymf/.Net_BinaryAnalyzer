using BinaryAnalyzer.CustomException;
using BinaryAnalyzer.Generator;
using BinaryAnalyzer.Struct;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Misc
{
    class Assert
    {
        /// <summary>
        /// 限定id只能在 (0,0xFFFF) 范围内
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static public void IsObjectId(int value)
        {
            if (value <= 0 || value >= 0xFFFF)
            {
                throw new RollBackException();
            }
        }

        /// <summary>
        /// 限定id只能在 (0,0xFFFF) 范围内
        /// </summary>
        /// <param name="idRef"></param>
        static public void IsIdRef(int value)
        {
            if (value <= 0 || value >= 0xFFFF)
            {
                throw new RollBackException();
            }
        }

        /// <summary>
        /// 限定id只能在 (0,0xFFFF) 范围内
        /// </summary>
        /// <param name="libraryId"></param>
        static public void IsLibraryId(int value)
        {
            if (value <= 0 || value >= 0xFFFF)
            {
                throw new RollBackException();
            }
        }

        /// <summary>
        /// 检查是否符合 MessageFlags 的值
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
        static public void IsMessageFlags(MessageFlags flags)
        {
            if (flags < MessageFlags.NoArgs || flags > MessageFlags.GenericMethod)
            {
                throw new RollBackException();
            }
        }

        /// <summary>
        /// 检查是否符合 BinaryArrayTypeEnumeration 的值
        /// </summary>
        /// <param name="value"></param>
        static public void IsBinaryArrayTypeEnum(BinaryArrayTypeEnumeration value)
        {
            if (value < BinaryArrayTypeEnumeration.Single || value > BinaryArrayTypeEnumeration.RectangularOffset)
            {
                throw new RollBackException();
            }
        }

        /// <summary>
        /// 检查是否符合 PrimitiveTypeEnumeration 的值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        static public void IsPrimitiveTypeEnum(PrimitiveTypeEnumeration value)
        {
            if (value < PrimitiveTypeEnumeration.Boolean || value > PrimitiveTypeEnumeration.String)
            {
                throw new RollBackException();
            }
        }

        /// <summary>
        /// 检查是否符合 BinaryTypeEnumeration 的值
        /// </summary>
        /// <param name="value"></param>
        static public void IsBinaryTypeEnum(BinaryTypeEnumeration value)
        {
            if (value < BinaryTypeEnumeration.Primitive || value > BinaryTypeEnumeration.PrimitiveArray)
            {
                throw new RollBackException();
            }
        }

        /// <summary>
        /// 检查是否为正整数，包含0
        /// </summary>
        /// <param name="value"></param>
        static public void IsPositiveIntegerIncludeZero(int value)
        {
            if (value < 0)
            {
                throw new RollBackException();
            }
        }

        /// <summary>
        /// 判断是否为字母
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        static public void IsLetter(Char ch)
        {
            if (ch >= 'A' && ch <= 'Z') return;
            if (ch >= 'a' && ch <= 'z') return;

            throw new RollBackException();
        }

        /// <summary>
        /// 判断是否为空
        /// </summary>
        /// <param name="obj"></param>
        static public void IsNotNull(object obj)
        {
            if (obj == null)
            {
                throw new RollBackException();
            }
        }

        /// <summary>
        /// 判断字符串是否为空
        /// </summary>
        /// <param name="obj"></param>
        static public void IsNotEmpty(string obj)
        {
            if (string.IsNullOrEmpty(obj))
            {
                throw new RollBackException();
            }
        }

        /// <summary>
        /// 是否为成员名
        /// </summary>
        /// <param name="obj"></param>
        static public void IsMemberName(string obj)
        {
            if (!string.IsNullOrEmpty(obj) && obj.Length > 0)
            {
                //属性
                if (obj.Contains(CSGenerator.k_BackingField)) return;

                var ch = obj[0];
                if (ch == '_') return;
                if (ch >= 'A' && ch <= 'Z') return;
                if (ch >= 'a' && ch <= 'z') return;
            }

            throw new RollBackException();
        }
    }
}
