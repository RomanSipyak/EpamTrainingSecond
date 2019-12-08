// <copyright file="ReflectionImplementation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RunProject.RunImplementations.Training6
{
    using System;
    using System.Reflection;
    using PrinterHelpers;
    using PrinterHelpers.PrintersImplementations;

    public class ReflectionImplementation : IRun
    {
        public ReflectionImplementation(IPrinter printer)
        {
            this.Printer = printer;
        }

        public IPrinter Printer { get; set; } = new ConsolePrinter();

        public bool Run()
        {
            this.Printer.Writeline("Do reflection for path " + @"C:\Users\GOOD\source\repos\EpamTrainingSecond\Training1\bin\Debug\Training1.dll");
            this.ReflectionContext(@"C:\Users\GOOD\source\repos\EpamTrainingSecond\Training1\bin\Debug\Training1.dll");
            this.Printer.Writeline("Do reflection for path " + @"C:\Users\GOOD\source\repos\EpamTrainingSecond\Training2\bin\Debug\Training2.dll");
            this.ReflectionContext(@"C:\Users\GOOD\source\repos\EpamTrainingSecond\Training2\bin\Debug\Training2.dll");
            this.Printer.Writeline("Do reflection for path " + @"C:\Users\GOOD\source\repos\EpamTrainingSecond\Training3\bin\Debug\Training3.dll");
            this.ReflectionContext(@"C:\Users\GOOD\source\repos\EpamTrainingSecond\Training3\bin\Debug\Training3.dll");
            this.Printer.Writeline("Do reflection for path " + @"C:\Users\GOOD\source\repos\EpamTrainingSecond\Training5\bin\Debug\Training5.dll");
            this.ReflectionContext(@"C:\Users\GOOD\source\repos\EpamTrainingSecond\Training5\bin\Debug\Training5.dll");
            return true;
        }

        private void ReflectionContext(string path)
        {
            Assembly assembly = Assembly.LoadFrom(path);
            //// Вивід інформації про модулі збірки
            foreach (Module md in assembly.GetModules(true))
            {
                this.Printer.Writeline(md.ToString());
            }
            //// Вивід інформації про типи збірки.
            foreach (Type t in assembly.GetExportedTypes())
            {
                this.Printer.Writeline(t.ToString());
                foreach (MemberInfo m in t.GetMembers())
                {
                    this.Printer.Writeline($"{m.DeclaringType} {m.MemberType} {m.Name}");

                    if (m.MemberType == MemberTypes.Constructor)
                    {
                        ConstructorInfo constructor = (ConstructorInfo)m;
                        string modificator = "Constructor ==> ";
                        if (constructor.IsPublic)
                        {
                            modificator += "public ";
                        }

                        if (constructor.IsPrivate)
                        {
                            modificator += "private ";
                        }

                        this.Printer.Write($"{modificator} {t.Name} (");
                        foreach (ParameterInfo p in ((ConstructorInfo)m).GetParameters())
                        {
                            this.Printer.Write($"{p.ParameterType.Name} {p.Name}");
                            if (p.Position + 1 < ((ConstructorInfo)m).GetParameters().Length)
                            {
                                this.Printer.Write(", ");
                            }
                        }

                        this.Printer.Writeline(")");
                    }

                    if (m.MemberType == MemberTypes.Method)
                    {
                        MethodInfo method = (MethodInfo)m;
                        string modificator = "Method ==> ";
                        if (method.IsStatic)
                        {
                            modificator += "static ";
                        }

                        if (method.IsVirtual)
                        {
                            modificator += "virtual";
                        }

                        this.Printer.Write($"{modificator} {method.ReturnType.Name} {method.Name} (");
                        foreach (ParameterInfo p in ((MethodInfo)m).GetParameters())
                        {
                            this.Printer.Write($"{p.ParameterType.Name} {p.Name}");
                            if (p.Position + 1 < ((MethodInfo)m).GetParameters().Length)
                            {
                                this.Printer.Write(", ");
                            }
                        }

                        this.Printer.Writeline(")");
                    }
                }
            }
        }
    }
}
