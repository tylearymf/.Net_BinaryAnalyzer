using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BinaryAnalyzer.Attribute;
using BinaryAnalyzer.RecordTypeHandler;
using BinaryAnalyzer.Struct;

namespace BinaryAnalyzer
{
    class BinaryAnalyze : IAnalyze
    {
        BinaryReader IAnalyze.Reader { set; get; }
        Action<BinaryAnalyze> onFinished { set; get; }

        public List<IRecordObject> recordObjects { protected set; get; }

        static Dictionary<RecordTypeEnumeration, IRecordTypeHandler> recordTypeHandlerDic;
        static bool isInitDic;
        bool isStart;

        static BinaryAnalyze()
        {
            if (isInitDic) return;
            isInitDic = true;

            recordTypeHandlerDic = new Dictionary<RecordTypeEnumeration, IRecordTypeHandler>();
            var ass = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var item in ass)
            {
                var types = item.GetTypes();
                foreach (var type in types)
                {
                    var attr = type.GetCustomAttributes(typeof(HandlerAttribute), false);
                    if (attr.Length == 0) continue;
                    var handlerAttr = attr[0] as HandlerAttribute;
                    var handler = Activator.CreateInstance(type) as IRecordTypeHandler;
                    if (handler == null) throw new NullReferenceException("handler is null");
                    recordTypeHandlerDic.Add(handlerAttr.RecordType, handler);
                }
            }
        }

        public BinaryAnalyze(BinaryReader br, Action<BinaryAnalyze> onFinished)
        {
            ((IAnalyze)this).Reader = br;
            this.onFinished = onFinished;
            recordObjects = new List<IRecordObject>();
        }

        public void StartAnalyze()
        {
            if (isStart) return;
            isStart = true;

            AnalyzeNextByte();
        }

        void AnalyzeNextByte()
        {
            var reader = ((IAnalyze)this).Reader;

            if (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                var recordType = (RecordTypeEnumeration)reader.ReadByte();
                //while (recordType == RecordTypeEnumeration.SerializedStreamHeader)
                //{
                //    if (reader.BaseStream.Position == 1)
                //    {
                //        break;
                //    }
                //    else
                //    {
                //        recordType = (RecordTypeEnumeration)reader.ReadByte();
                //    }
                //}

                HandleRecordType(recordType);
            }
            else
            {
                onFinished?.Invoke(this);
            }
        }

        void HandleRecordType(RecordTypeEnumeration recordType)
        {
            if (recordTypeHandlerDic.TryGetValue(recordType, out var handler))
            {
                try
                {
                    var recordObject = handler?.Handle(this);
                    RecordObject(recordObject);
                    AnalyzeNextByte();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        void RecordObject(IRecordObject obj)
        {
            if (obj == null) throw new NullReferenceException("recordObject is null");
            recordObjects.Add(obj);
        }
    }
}
