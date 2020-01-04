using System;
using System.IO;

namespace BinaryAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("拖入需要反序列化的文件/输入文件路径：");
                var input = Console.ReadLine();

                if (!File.Exists(input))
                {
                    Console.WriteLine("文件不存在");
                }

                FileStream fs = null;
                BinaryReader br = null;

                var msg = string.Empty;
                try
                {
                    fs = new FileStream(input, FileMode.Open);
                    br = new BinaryReader(fs);

                    var analyze = new BinaryAnalyze(br, OnAnalyzeFinished);
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
        }

        static void OnAnalyzeFinished(BinaryAnalyze analyze)
        {
            Console.WriteLine("Analyze Finished");

            foreach (var item in analyze.recordObjects)
            {
                Console.WriteLine(item);
            }
        }
    }
}
