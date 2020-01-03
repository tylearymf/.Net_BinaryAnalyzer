using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The MethodReturnCallArray is a special use of the ArraySingleObject record. The record represents a serialized Array that can contain instances of any Remoting Type. The items of the Array include Return Value, Output Arguments, Exception, Call Context, and Message Properties. Each item is conditional. The conditions for presence of the item are given with the definition of the item in the following list. The items, if present, MUST be in the following order
    /// </summary>
    class MethodReturnCallArray
    {
    }
}
