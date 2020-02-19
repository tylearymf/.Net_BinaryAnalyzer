using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

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
        /// <returns>namespace, classNames, genericTypeNames</returns>
        static public Tuple<string, List<string>, List<string>> GetNamespaceAndClassNames(string name)
        {
            try
            {
                var namespaceValue = string.Empty;
                var classNames = new List<string>();
                var genericTypeNames = new List<string>();

                //generic
                var index = name.IndexOf("[");
                if (index != -1)
                {
                    var arg = name.Substring(index, name.Length - index);
                    genericTypeNames = GetGenericTypeNames(arg);

                    name = name.Substring(0, index);
                }

                var splits = name.Split('+').ToList();
                var namespaceSplits = splits[0].Split('.').ToList();
                splits.RemoveAt(0);

                if (namespaceSplits.Count == 1)
                {
                    classNames.Add(namespaceSplits[0]);
                }
                else
                {
                    classNames.Add(namespaceSplits[namespaceSplits.Count - 1]);
                    namespaceSplits.RemoveAt(namespaceSplits.Count - 1);
                    namespaceValue = string.Join('.', namespaceSplits.ToArray());
                }

                foreach (var item in splits)
                {
                    var index1 = item.IndexOf('`');
                    var className = item;

                    if (index1 != -1)
                    {
                        var genericCount = int.Parse(item.Substring(index1 + 1, item.Length - index1 - 1));
                        className = item.Substring(0, index1);

                        var temp = new List<string>();
                        for (int i = 0; i < genericCount; i++)
                        {
                            temp.Add("T" + i);
                        }

                        className = string.Format("{0}<{1}>", className, string.Join(", ", temp.ToArray()));
                    }

                    classNames.Add(className);
                }

                return new Tuple<string, List<string>, List<string>>(namespaceValue, classNames, genericTypeNames);
            }
            catch (Exception ex)
            {
                Console.WriteLine("类名解析失败.\n" + ex.ToString());
            }

            throw new Exception("类名解析失败");
        }

        static public List<string> GetGenericTypeNames(string str)
        {
            var genericTypeNames = new List<List<char>>();
            var chars = str.ToCharArray();

            const int CommaCount1 = 4;
            const int CommaCount2 = 5;

            var isAdd = false;
            var isBracketBreak = false;
            var isEnd = false;
            var leftBracket = 0;
            var rightBracket = 0;
            var commaCount = CommaCount1;

            var list = new List<char>();
            genericTypeNames.Add(list);

            for (int i = chars.Length - 1; i >= 0; i--)
            {
                var ch = chars[i];

                if (!isAdd)
                {
                    if (ch == ',')
                    {
                        commaCount--;

                        if (commaCount == 0)
                        {
                            isAdd = true;
                        }
                    }
                }
                else
                {
                    if (isEnd || (isBracketBreak && (ch == '[' || ch == ']')))
                    {
                        commaCount = CommaCount2;

                        if (isEnd && ch == ',')
                        {
                            commaCount--;
                        }

                        isAdd = false;
                        isEnd = false;
                        isBracketBreak = false;
                        leftBracket = 0;
                        rightBracket = 0;

                        list = new List<char>();
                        genericTypeNames.Add(list);

                        continue;
                    }

                    switch (ch)
                    {
                        case '[':
                            leftBracket++;

                            if (leftBracket >= rightBracket)
                            {
                                isBracketBreak = true;
                            }

                            if (leftBracket > rightBracket)
                            {
                                isEnd = true;
                                continue;
                            }

                            break;
                        case ']':
                            rightBracket++;
                            break;
                        default:
                            break;
                    }

                    list.Add(ch);
                }
            }

            //移除末尾空数组
            if (genericTypeNames[genericTypeNames.Count - 1].Count == 0)
            {
                genericTypeNames.RemoveAt(genericTypeNames.Count - 1);
            }

            genericTypeNames.Reverse();
            var temp = new List<string>();
            foreach (var item in genericTypeNames)
            {
                item.Reverse();
                temp.Add(new string(item.ToArray()));
            }

            return temp;
        }
    }
}
