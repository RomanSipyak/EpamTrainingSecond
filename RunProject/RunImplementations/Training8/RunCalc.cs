using PrinterHelpers;
using PrinterHelpers.PrintersImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training8;

namespace RunProject.RunImplementations.Training8
{
    public class RunCalc : IRun
    {
        public bool Run()
        {
            try
            {
                Carculator calculatorConsole = new Carculator(new PrinterToConsole());
                calculatorConsole.SimpleOperations(Carculator.Operations.Divide);
                calculatorConsole.SimpleOperations(Carculator.Operations.Multiply);
                calculatorConsole.SimpleOperations(Carculator.Operations.Minus);
                calculatorConsole.SimpleOperations(Carculator.Operations.Plus);
                Carculator calculatorFile = new Carculator(new PrinterToFile());
                calculatorFile.SimpleOperations(Carculator.Operations.Divide);
                calculatorFile.SimpleOperations(Carculator.Operations.Multiply);
                calculatorFile.SimpleOperations(Carculator.Operations.Minus);
                calculatorFile.SimpleOperations(Carculator.Operations.Plus);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
                return false;
            }
        }
    }
}
