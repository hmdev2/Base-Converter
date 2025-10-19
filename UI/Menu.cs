
using System.Text;
using BaseConverter.Exceptions;

namespace BaseConverter.UI
{
    class Menu
    {
        public static void Start()
        {
            ShowMainMenu();

            try
            {
                ConsoleHandler.ReadInput();
            }
            catch(ConverterException ex)
            {
                Console.WriteLine("\n" + ex.Message);
                Console.Write("\n\nAperte Enter para continuar...");
                Console.ReadLine();
                Start();
            }
        }
        private static void ShowMainMenu()
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();
            sb.Append(@"
   ____   ___   _   _     _     ____  __   __     ____   ___   _   _ __     __ _____  ____   _____  _____  ____
  | __ ) |_ _| | \ | |   / \   |  _ \ \ \ / /    / ___| / _ \ | \ | |\ \   / /| ____||  _ \ |_   _|| ____||  _ \
  |  _ \  | |  |  \| |  / _ \  | |_) | \ v /    | |    | | | ||  \| | \ \ / / |  _|  | |_) |  | |  |  _|  | |_) |
  | |_) | | |  | |\  | / ___ \ |  _ <   | |     | |___ | |_| || |\  |  \ V /  | |___ |  _ <   | |  | |___ |  _ <
  |____/ |___| |_| \_|/_/   \_\|_| \_\  |_|      \____| \___/ |_| \_|   \_/   |_____||_| \_\  |_|  |_____||_| \_\
");
            sb.AppendLine("");
            sb.AppendLine("Selecione uma opção:");
            sb.AppendLine("");
            sb.AppendLine("[1] Para converter de decimal para binário");
            sb.AppendLine("[2] Para converter de binário para decimal");
            sb.AppendLine("\nDigite \"exit\" Para sair...");
            sb.AppendLine("");
            sb.Append("Opção > ");
            Console.Write(sb.ToString());
        }
    }
}