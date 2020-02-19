# .Net_BinaryAnalyzer(Parse .Net serialization)
##该软件用于分析通过BinaryFormatter序列化后的.Net对象，产生类结构信息<br/>

### 使用方法<br/>
1、双击运行BinaryAnalyzer.exe,然后拖入需要反序列的文件，默认会文件的同级目录下生成cs文件<br/>
2、运行cmd，输入命令：BinaryAnalyzer.exe test.bin，默认会文件的同级目录下生成cs文件<br/>

### 问题<br/>
· 复杂的泛型解析时会可能会出错（比如下面这两种情况）<br/>
```
第一种：
//正常生成
public class Test<T0,T1>
{
	//正常生成
	public T0 a;
	//T0不为Int32时正常生成，反之则会生成为 public T0 b;
	public Int32 b;
}
第二种：
//正常生成
public class Test<T0>
{
	//这里识别不了Test1的泛型类型，所以为默认值T0，但可能实际代码是T1
	public class Test1<T0>
	{
		//正常生成
		public T0 a;
		public T1 b;
		
		//暂时识别不了该类型
		public Test<T0>.Test1<T1> c;
	}
}
```