using BinaryAnalyzer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BinaryAnalyzer.Struct;
using System.IO;
using System.Text.RegularExpressions;
using BinaryAnalyzer.Extensions;

namespace BinaryAnalyzer.Generator
{
    class CSGenerator
    {
        const string k_BackingField = "k__BackingField";
        class GenerateInfo
        {
            public ClassInfo ClassInfo;
            public MemberTypeInfo MemberTypeInfo;
        }

        static public void Generate(List<IRecordObject> recordObjects, string csFilePath)
        {
            var list = recordObjects.FindAll(x => x is ClassWithMembersAndTypes || x is SystemClassWithMembersAndTypes).ConvertAll(x =>
            {
                if (x is ClassWithMembersAndTypes)
                {
                    var c = x as ClassWithMembersAndTypes;
                    return new GenerateInfo() { ClassInfo = c.ClassInfo, MemberTypeInfo = c.MemberTypeInfo };
                }
                else if (x is SystemClassWithMembersAndTypes)
                {
                    var c = x as SystemClassWithMembersAndTypes;
                    return new GenerateInfo() { ClassInfo = c.ClassInfo, MemberTypeInfo = c.MemberTypeInfo };
                }

                return new GenerateInfo();
            });

            var builder = new StringBuilder(2048);
            builder.AppendLine("using System;");
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine();

            foreach (var item in list)
            {
                if (item.ClassInfo == null || item.MemberTypeInfo == null) continue;

                var tupleInfo = CSExtensions.GetClassNameTree(item.ClassInfo.Name.Value);
                ////系统类跳过
                //if (className.StartsWith("System")) continue;

                var memberCount = item.ClassInfo.MemberCount;
                var memberNames = item.ClassInfo.MemberNames.ToList().ConvertAll(x => x.Value);
                var binaryTypeEnums = item.MemberTypeInfo.BinaryTypeEnums;
                var additionalInfos = item.MemberTypeInfo.AdditionalInfos;

                var hasNamespace = !string.IsNullOrEmpty(tupleInfo.Item1);
                var hasClass1 = !string.IsNullOrEmpty(tupleInfo.Item2);
                var hasClass2 = !string.IsNullOrEmpty(tupleInfo.Item3);
                var tabIndex = 0;

                if (hasNamespace)
                {
                    builder.AppendFormat("namespace {0}", tupleInfo.Item1);
                    builder.AppendLine();
                    builder.AppendLine("{");
                    tabIndex++;
                }
                if (hasClass1)
                {
                    builder.AppendFormat("{0}class {1}", new string('\t', tabIndex), tupleInfo.Item2);
                    builder.AppendLine();
                    builder.AppendFormat("{0}{{", new string('\t', tabIndex));
                    builder.AppendLine();
                    tabIndex++;
                }
                if (hasClass2)
                {
                    builder.AppendFormat("{0}class {1}", new string('\t', tabIndex), tupleInfo.Item3);
                    builder.AppendLine();
                    builder.AppendFormat("{0}{{", new string('\t', tabIndex));
                    builder.AppendLine();
                    tabIndex++;
                }
                {
                    for (int i = 0; i < memberCount; i++)
                    {
                        var memberName = memberNames[i];
                        var binaryTypeEnum = binaryTypeEnums[i];
                        var additionalInfo = additionalInfos[i];
                        var memberType = string.Empty;

                        switch (binaryTypeEnum)
                        {
                            case BinaryTypeEnumeration.Primitive:
                            case BinaryTypeEnumeration.PrimitiveArray:
                                memberType = additionalInfo.ToString();
                                break;
                            case BinaryTypeEnumeration.String:
                                memberType = "string";
                                break;
                            case BinaryTypeEnumeration.Object:
                                memberType = "object";
                                break;
                            case BinaryTypeEnumeration.SystemClass:
                                memberType = additionalInfo.ToString();
                                break;
                            case BinaryTypeEnumeration.Class:
                                var info = additionalInfo as ClassTypeInfo;
                                memberType = info.TypeName.Value;
                                break;
                            default:
                                throw new NotImplementedException("BinaryTypeEnumeration：" + binaryTypeEnum);
                        }

                        var isProperty = memberName.Contains(k_BackingField);
                        if (isProperty)
                        {
                            var match = Regex.Match(memberName, string.Format("<(.*?)>{0}", k_BackingField));
                            memberName = match.Groups[1].Value;
                        }

                        if (CSExtensions.IsKeyword(memberName))
                        {
                            memberName = "@" + memberName;
                        }
                        memberType = memberType.Replace("+", ".");

                        builder.AppendFormat("{0}public {1} {2}{3}", new string('\t', tabIndex), memberType, memberName, isProperty ? " { set; get; }" : ";");
                        builder.AppendLine();
                    }
                }
                if (hasClass2)
                {
                    tabIndex--;
                    builder.AppendFormat("{0}}}", new string('\t', tabIndex));
                    builder.AppendLine();
                }
                if (hasClass1)
                {
                    tabIndex--;
                    builder.AppendFormat("{0}}}", new string('\t', tabIndex));
                    builder.AppendLine();
                }
                if (hasNamespace)
                {
                    tabIndex--;
                    builder.AppendLine("}");
                    builder.AppendLine();
                }
            }

            File.WriteAllText(csFilePath, builder.ToString());
        }
    }
}