using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace TestConsole
{

    public class CodeTest
    {

        public static T CreateInstance<T>(string fullName, string assemblyName)
        {
            string path = fullName + "," + assemblyName;//命名空间.类型名,程序集
            Type o = Type.GetType(path);//加载类型
            object obj = Activator.CreateInstance(o, true);//根据类型创建实例
            return (T)obj;//类型转换并返回
        }

        public static string CreateInstance(string classname, string classtitle = "")
        {
            var test = CreateInstance<TestBase>(classname, "TestConsole");
            if (test != null)
            {
                Console.WriteLine("\r\n*** 【Start：" + classname + "】***************************\r\n");
                test.RunTest();
                Console.WriteLine("\r\n*** 【End：" + classname + "】***************************\r\n");
                return "";
            }
            else return "获取的操作类不存在！";
        }

        //public static void Main(string[] args)
        //{
        //    new TestItem.BatchImageDownload().RunTest();
        //}


        public static void Main(string[] args)
        {
            List<Type> typelist = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(TestBase)))).ToList();
            Dictionary<string, string> dicKeys = new Dictionary<string, string>();
            foreach (var item in typelist)
            {
                object[] attrObjs = item.GetCustomAttributes(typeof(TestAttribute), false);
                if (attrObjs.Count() == 0)
                {
                    dicKeys.Add(item.FullName, "未定义名称");
                    continue;
                }
                foreach (var attr in attrObjs)
                {
                    TestAttribute testAb = attr as TestAttribute;
                    if (testAb != null)
                    {
                        dicKeys.Add(item.FullName, testAb.Title);
                    }
                }
            }

        SelectItem:
            Console.WriteLine("=  测试功能选择项========================================\r\n=  ");
            int i = 0;
            foreach (var item in dicKeys.Keys)
            {
                Console.WriteLine(string.Format("=  {0}：{1}{2}", (++i), item, dicKeys[item]));
            }
            Console.WriteLine("=  \r\n=========================================");
            Console.Write("请输入你要执行的内容（序号或者类名）：");
            string input = Console.ReadLine();

            string inputResult = "";
            if (Regex.IsMatch(input, "^[0-9]*$"))
            {
                //如果是数字
                if (dicKeys.Count() >= Convert.ToInt32(input))
                {
                    var kv = dicKeys.ElementAt(Convert.ToInt32(input) - 1);
                    inputResult = CreateInstance(kv.Key);
                }
                else
                    inputResult = "输入的编号不存在";
            }
            else
            {
                //类名操作
                if (dicKeys.Keys.Select(s => s.ToLower()).Contains(input.ToLower()))
                {
                    var key = dicKeys.Keys.Where(w => w.ToLower() == input.ToLower()).First();
                    inputResult = CreateInstance(key);
                }
                else inputResult = "输入的类名不存在";
            }
            if (!string.IsNullOrEmpty(inputResult))
            {
                Console.WriteLine("\r\n 输入异常：" + inputResult);
            }
            Console.WriteLine("");
            Console.WriteLine("");
            goto SelectItem;

            Console.ReadKey();
        }
    }
}
