using BinaryAnalyzer.Generator;
using System;
using System.IO;

namespace BinaryAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Deserialize(args[0]);
                return;
            }

            while (true)
            {
                Console.WriteLine("拖入需要反序列化的文件/输入文件路径：");
                var input = Console.ReadLine().Trim('"');

                if (!File.Exists(input))
                {
                    Console.WriteLine("文件不存在");
                }

                Deserialize(input);
            }
        }

        static void Deserialize(string filePath)
        {
            FileStream fs = null;
            BinaryReader br = null;
            var msg = string.Empty;
            try
            {
                fs = new FileStream(filePath, FileMode.Open);
                br = new BinaryReader(fs);

                var analyze = new BinaryAnalyze(filePath, br, OnAnalyzeFinished);
                analyze.StartAnalyze();
                msg = "反序列化完成.";
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
            }
            finally
            {
                Console.WriteLine(msg);
                fs?.Close();
                br?.Close();
            }
        }

        static void OnAnalyzeFinished(BinaryAnalyze analyze)
        {
            Console.WriteLine("Analyze Finished");

            foreach (var item in analyze.RecordObjects)
            {
                Console.WriteLine(item);
            }

            var fileInfo = new FileInfo(analyze.FilePath);
            var csFilePath = Path.Combine(fileInfo.DirectoryName, fileInfo.Name.Replace(fileInfo.Extension, string.Empty) + ".cs");
            CSGenerator.Generate(analyze.RecordObjects, csFilePath);
        }
    }
}
