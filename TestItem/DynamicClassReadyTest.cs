using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.TestItem
{
    [Test("动态类读取测试")]
    public class DynamicClassReadyTest : TestBase
    {
        public void RunTest()
        {
            CSharpCodeProvider objcsp = new CSharpCodeProvider();
            ICodeCompiler objICodeCompiler = objcsp.CreateCompiler();

            CompilerParameters objCompilerParameters = new CompilerParameters();

            objCompilerParameters.ReferencedAssemblies.Add("System.dll");


            //是否生成可执行文件
            objCompilerParameters.GenerateExecutable = false;

            //是否生成在内存中
            objCompilerParameters.GenerateInMemory = true;

            string code = "using System.Windows.Forms; public class Test {    public void Hello(){    }   }";

            //编译代码
            CompilerResults cr = objICodeCompiler.CompileAssemblyFromSource(objCompilerParameters, code);

            if (cr.Errors.HasErrors)
            {
                var msg = string.Join(Environment.NewLine, cr.Errors.Cast<CompilerError>().Select(err => err.ErrorText));
                Console.WriteLine("编译错误");
            }
            else
            {
                Assembly objAssembly = cr.CompiledAssembly;
                object objHelloWorld = objAssembly.CreateInstance("Test");
                MethodInfo objMI = objHelloWorld.GetType().GetMethod("Hello");
                objMI.Invoke(objHelloWorld, null);
            }

        }
    }
}
