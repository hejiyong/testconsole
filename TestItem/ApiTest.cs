﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.TestItem
{
    [Test("API测试方法")]
    public class ApiTest : TestBase
    {
        public void RunTest()
        {
            Console.WriteLine("Api测试成功");
        }
    }
}
