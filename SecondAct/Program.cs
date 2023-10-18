using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondAct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Type t = typeof(MyTestClass);

            //MethodInfo[] mArr = t.GetMethods();
            //foreach(var m in mArr)
            //{
            //    Console.WriteLine($"--> {m.ReturnType.Name}\t {m.Name}");
            //    ParameterInfo[] pArr = m.GetParameters();
            //    foreach(var p in pArr)
            //    {
            //        Console.WriteLine($"-->{p.ParameterType.Name}\t {p.Name}");
            //    }
            //}
            Assembly assembly = Assembly.LoadFrom(@"C:\temp\GeneratorName.dll");
            Type[] types = assembly.GetTypes();
            foreach (Type t in types)
            {
                if(t.IsClass && t.Name == "Generator")
                {
                    Console.WriteLine($"{t.FullName}\t {t.Name}");
                    object obj = Activator.CreateInstance(t);

                    foreach(MethodInfo info in obj.GetType().GetMethods())
                    {
                        Console.WriteLine($"--> {info.Name}\t {info.ReturnType}");
                        foreach(ParameterInfo parameterInfo in info.GetParameters())
                        {
                            Console.WriteLine($"--> {parameterInfo.Name}\t {parameterInfo.ParameterType.BaseType}");
                            if(parameterInfo.ParameterType.BaseType == typeof(Enum))
                            {
                                 foreach(FieldInfo f in parameterInfo.ParameterType.GetFields())
                                {
                                    Console.WriteLine($" --> {f.Name}");
                                }
                            }
                        }
                    }
                }

            }
            Type tGenerate = types.FirstOrDefault(f => f.IsClass && f.Name == "Generator");
            object exGenerator = Activator.CreateInstance(tGenerate);
            var method = exGenerator.GetType().GetMethod("GenerateDefault");
            var pGender = method.GetParameters()[0];
            var fGender = pGender.ParameterType.GetFields();
            object gender = null;
            var EnumType = Enum.ToObject(pGender.ParameterType, 0);
            object[] param = new object[] { gender };
            var result = method.Invoke(exGenerator, param);
            Console.WriteLine(result);
            string test = "";
            Console.ReadKey();
        }
    }
}
