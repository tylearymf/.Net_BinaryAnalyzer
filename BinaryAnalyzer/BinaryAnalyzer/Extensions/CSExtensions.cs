using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BinaryAnalyzer.Extensions
{
    class CSExtensions
    {
        //c# keywords https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/
        static HashSet<string> s_Keywords = new HashSet<string>()
        {
            "abstract","as","base","bool",
            "break","byte","case","catch",
            "char","checked","class","const",
            "continue","decimal","default","delegate",
            "do","double","else","enum",
            "event","explicit","extern","false",
            "finally","fixed","float","for",
            "foreach","goto","if","implicit",
            "in","int","interface","internal",
            "is","lock","long","namespace",
            "new","null","object","operator",
            "out","override","params","private",
            "protected","public","readonly","ref",
            "return","sbyte","sealed","short",
            "sizeof","stackalloc","static","string",
            "struct","switch","this","throw",
            "true","try","typeof","uint",
            "ulong","unchecked","unsafe","ushort",
            "using","using static","virtual","void",
            "volatile","while",
        };

        /// <summary>
        /// 是否为关键字
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static public bool IsKeyword(string name)
        {
            return s_Keywords.Contains(name);
        }

        /// <summary>
        /// 解析类名
        /// </summary>
        /// <param name="name"></param>
        /// <returns>namespace,class1,class2</returns>
        static public Tuple<string, string, string> GetClassNameTree(string name)
        {
            if (name.Contains("`"))
            {
                throw new Exception("暂不支持泛型解析");
            }

            var index = name.IndexOf("+");
            var lastIndex = name.LastIndexOf("+");
            if (index != -1 && lastIndex != -1 && index != lastIndex)
            {
                throw new Exception("暂不支持嵌套结构解析");
            }

            var match = Regex.Match(name, @"((?<namespace>[\w\.]+)\.)?(?<class1>\w+)(\+(?<class2>\w+))?");
            if (!match.Success)
            {
                throw new Exception("类名解析失败");
            }

            return new Tuple<string, string, string>(match.Groups["namespace"].Value, match.Groups["class1"].Value, match.Groups["class2"].Value);
        }
    }
}
