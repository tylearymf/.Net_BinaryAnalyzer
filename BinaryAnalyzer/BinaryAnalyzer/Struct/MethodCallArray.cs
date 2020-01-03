using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Struct
{
    /// <summary>
    /// The MethodCallArray is a special use of the ArraySingleObject record. The record represents a serialized Array that can contain instances of any Remoting Type. The items of the Array include Input Arguments, Generic Type Arguments, Method Signature, Call Context, and Message Properties. Each item is conditional. The conditions for presence of the item are given with the definition of each item. The items, if present, MUST be in the following order
    /// </summary>
    class MethodCallArray
    {
    }
}
