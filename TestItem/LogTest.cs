using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Net;
using System.IO;
using log4net;

namespace TestConsole.TestItem
{
    [Test("日志测试")]
    public class LogTest : TestBase
    {
        public static ILog log = LogManager.GetLogger("TimingLogger");

        public void RunTest()
        {
            log.Info("测试日志功能");

            Console.WriteLine("记录日志结束");
        }
    }
}
