namespace GestaoEquipamentos.ConsoleApp
{
    public class Menu
    {
        private Estoque estoque;

        public Menu(Estoque estoque)
        {
            this.estoque = estoque;
        }

        public void ExibirMenu()
        {
            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("Bem-vindo ao Sistema de Gestão de Estoque!\n");
                Console.WriteLine("Escolha uma opção:");

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("1.");
                Console.ResetColor();
                Console.WriteLine("Cadastrar novo produto");

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("2.");
                Console.ResetColor();
                Console.WriteLine( "Listar todos os produtos");

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("3.");
                Console.ResetColor();
                Console.WriteLine("Atualizar um produto existente");

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("4.");
                Console.ResetColor();
                Console.WriteLine("Remover um produto");

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("5.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sair\n");
                Console.ResetColor();

                Console.Write("Digite o número da opção desejada: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        estoque.Create();
                        break;
                    case "2":
                        estoque.Read();
                        break;
                    case "3":
                        estoque.Update();
                        break;
                    case "4":
                        estoque.Delete();
                        break;
                    case "5":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }

                if (continuar)
                {
                    Console.ReadKey();
                }
            }
        }

        public static void Rodape()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("+------+------------------+----------------------+-------------------------+------------------+---------------------+");
        }

        public static void Cabecalho()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+------+------------------+----------------------+-------------------------+------------------+---------------------+");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("|  ID  |");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("      Série       |    Nome do Produto   |   Data de Fabricação    |    Fabricante    |  Preço do Produto   |");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("+------+------------------+----------------------+-------------------------+------------------+---------------------+");
        }
    }
}
