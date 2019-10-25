using PrinterHelpers;
using PrinterHelpers.PrintersImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RunProject.RunImplementations.Training6
{
   public class ReflectionImplementation : IRun
    {
        public ReflectionImplementation(IPrinter printer)
        {
            this.Printer = printer;
        }

        public IPrinter Printer { get; set; } = new ConsolePrinter();

        public bool Run()
        {
            ReflectionContext(@"C:\Users\GOOD\source\repos\EpamTrainingSecond\Training1\bin\Debug\Training1.dll");
            ReflectionContext(@"C:\Users\GOOD\source\repos\EpamTrainingSecond\Training2\bin\Debug\Training2.dll");
            ReflectionContext(@"C:\Users\GOOD\source\repos\EpamTrainingSecond\Training3\bin\Debug\Training3.dll");
            ReflectionContext(@"C:\Users\GOOD\source\repos\EpamTrainingSecond\Training5\bin\Debug\Training5.dll");
            return true;
        }

        private void ReflectionContext(string path)
        {
            Assembly assembly = Assembly.LoadFrom(path);
            // Вивід інформації про модулі збірки
            foreach (Module md in assembly.GetModules(true))
            {
                Printer.Writeline(md.ToString());
            }
            // Вивід інформації про типи збірки.
            foreach (Type t in assembly.GetExportedTypes())
            {
                Printer.Writeline(t.ToString());
                foreach (MemberInfo m in t.GetMembers())
                {
                    Printer.Writeline(m.ToString());
                    if (m.MemberType == MemberTypes.Method)
                    {
                        foreach (ParameterInfo p in ((MethodInfo)m).GetParameters())
                        {
                            Printer.Writeline(p.ToString());
                        }
                    }
                }
            }
        }
    }
}
