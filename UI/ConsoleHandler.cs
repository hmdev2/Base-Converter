using System;
using System.Globalization;
using BaseConverter.Core;
using BaseConverter.Models;

namespace BaseConverter.UI
{
    public class ConsoleHandler
    {
        public static void ReadInput()
        {
            string option = Console.ReadLine();
            CheckOption(option);
            
        }

        private static void CheckOption(string option)
        {
            string value;
            string result;
            Number num;

            switch(option)
            {
                case "1":
                    Console.Write("\nDigite um número na base (10): ");
                    value = Console.ReadLine();
                    num = new Number(value, "10");
                    result = DecimalToBinaryConverter.Convert(num);
                    PrintOutPut(result);
                    break;
                
                case "2":
                    Console.Write("\nDigite um número na base (2): ");
                    value = Console.ReadLine();
                    num = new Number(value, "2");
                    result = BinaryToDecimalConverter.Convert(num);
                    PrintOutPut(result);
                    break;
                
                case "exit":
                    Console.Clear();
                    break;
                    
                default:
                    Console.WriteLine("\nEscolha uma opção válida!");
                    Console.Write("\nOpção > ");
                    ReadInput();
                    break;
            }
        }

        private static void PrintOutPut(string result)
        {
            Console.Write("\nRESULTADO: ");
            Console.WriteLine(result + "\n");
            Console.Write("\n\nAperte Enter para continuar...");
            Console.ReadLine();
            Menu.Start();
        }
    }
}