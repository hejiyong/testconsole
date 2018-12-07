using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.TestItem
{
    [Test("键值对数组转换为对象")]
    public class DicToObject : TestBase
    {

        public const string key = "12345678";

        public void RunTest()
        {

            string str = @"
                测试第一行
                测试第二行
                测试第三行
            ";

            


            Dictionary<string, string> dic = new Dictionary<string, string> { 
                {"id","1"},
                {"name","测试"},
                {"createdt",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}
            };
            DicToObjectModel model = new DicToObjectModel();
            Type type = model.GetType();
            PropertyInfo[] ProList = type.GetProperties();
            foreach (var item in ProList)
            {

                var tc = Type.GetTypeCode(item.PropertyType);
                switch (tc)
                {
                    case TypeCode.Boolean:
                        break;
                    case TypeCode.Byte:
                        break;
                    case TypeCode.Char:
                        break;
                    case TypeCode.DBNull:
                        break;
                    case TypeCode.DateTime:
                        item.SetValue(model, Convert.ToDateTime(dic[item.Name]));
                        break;
                    case TypeCode.Decimal:
                        break;
                    case TypeCode.Double:
                        break;
                    case TypeCode.Empty:
                        break;
                    case TypeCode.Int16:
                        break;
                    case TypeCode.Int32:
                        item.SetValue(model, Convert.ToInt32(dic[item.Name]));
                        break;
                    case TypeCode.Int64:
                        break;
                    case TypeCode.Object:
                        break;
                    case TypeCode.SByte:
                        break;
                    case TypeCode.Single:
                        break;
                    case TypeCode.String:
                        item.SetValue(model, dic[item.Name].ToString());
                        break;
                    case TypeCode.UInt16:
                        break;
                    case TypeCode.UInt32:
                        break;
                    case TypeCode.UInt64:
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(model.name);
            Console.WriteLine(model.id);
            Console.WriteLine(model.createdt.ToString());
        }
    }

    public class DicToObjectModel
    {
        public int id { get; set; }

        public string name { get; set; }

        public DateTime createdt { get; set; }

    }
}
