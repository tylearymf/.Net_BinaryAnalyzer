using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryAnalyzer.Misc
{
    class Checker
    {
        /// <summary>
        /// 限定id只能在(0,0xFFFF)范围内
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        static public bool CheckId(int id)
        {
            if (id <= 0 || id >= 0xFFFF) return false;
            return true;
        }
    }
}
