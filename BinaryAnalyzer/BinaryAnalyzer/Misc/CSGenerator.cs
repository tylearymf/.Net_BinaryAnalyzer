using BinaryAnalyzer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BinaryAnalyzer.Struct;
using System.IO;
using System.Text.RegularExpressions;

namespace BinaryAnalyzer.Misc
{
    class CSGenerator
    {
        const string k_BackingField = "k__BackingField";

        static public void Generate(List<IRecordObject> recordObjects, string csFilePath)
        {
            var list = recordObjects.FindAll(x => x is ClassWithMembersAndTypes || x is SystemClassWithMembersAndTypes).ConvertAll(x =>
            {
                if (x is ClassWithMembersAndTypes)
                {
                    var c = x as ClassWithMembersAndTypes;
                    return new { ClasInfo = c.ClassInfo, MemberTypeInfo = c.MemberTypeInfo };
                }
                else if (x is SystemClassWithMembersAndTypes)
                {
                    var c = x as SystemClassWithMembersAndTypes;
                    return new { ClasInfo = c.ClassInfo, MemberTypeInfo = c.MemberTypeInfo };
                }

                throw new NotImplementedException();
            });

            var builder = new StringBuilder(2048);
            builder.AppendLine("using System;");
            builder.AppendLine("using System.Collections.Generic;");
            builder.AppendLine();

            foreach (var item in list)
            {
                var className = item.ClasInfo.Name.Value;
                ////系统类跳过
                //if (className.StartsWith("System")) continue;

                var memberCount = item.ClasInfo.MemberCount;
                var memberNames = item.ClasInfo.MemberNames.ToList().ConvertAll(x => x.Value);
                var binaryTypeEnums = item.MemberTypeInfo.BinaryTypeEnums;
                var additionalInfos = item.MemberTypeInfo.AdditionalInfos;

                builder.AppendFormat("class {0}", className);
                builder.AppendLine();
                builder.AppendLine("{");
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

                        builder.AppendFormat("\tpublic {0} {1}{2}", memberType, memberName, isProperty ? " { set; get; }" : ";");
                        builder.AppendLine();
                    }
                }
                builder.AppendLine("}");
                builder.AppendLine();
            }

            File.WriteAllText(csFilePath, builder.ToString());
        }
    }
}