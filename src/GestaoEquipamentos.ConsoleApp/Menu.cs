using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoEquipamentos.ConsoleApp
{
    public class Menu
    {
        public RepositórioEquipamentos estoque;
        public Equipamentos produtoEditado;

        public Menu(RepositórioEquipamentos estoque)
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

                ModificarCor("x", "1 - ");
                ModificarCor("", "Cadastrar novo produto\n");
                ModificarCor("x", "2 - ");
                ModificarCor("", "Listar todos os produtos\n");
                ModificarCor("x", "3 - ");
                ModificarCor("", "Atualizar um produto existente\n");
                ModificarCor("x", "4 - ");
                ModificarCor("", "Remover um produto\n");
                ModificarCor("x", "5 - ");
                ModificarCor("Erro", "Sair\n\n");


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

        public static int ExibirMenuEdicao()
        {
            int opcao = Program.ObterValor<int>("Digite qual campo deseja atualizar: \n" +
                                "1 - Serial\n" +
                                "2 - Nome\n" +
                                "3 - Data de fabricação\n" +
                                "4 - Fabricante\n" +
                                "5 - Preço\n");

            return opcao;
        }

        public static void ModificarCor(string cor, string resposta)
        {
            switch (cor)
            {
                case "Erro":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "Sucesso":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "Aviso":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case "x":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
            }
            Console.Write(resposta);
            Console.ResetColor();
        }

        #region Construtores de String/Tables
        public static void Rodape()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("+------+------------------+----------------------+-------------------------+------------------+---------------------+");
        }

        public static void Cabecalho(string tipo)
        {
            if (tipo == "Equipamento")
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
            else
            {

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("+------+----------------+-------------------------+---------------------+-----------------+\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("|  ID  |");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("     Nome     |       Descrição       |  Data do Chamado  |    Valor    |");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("+------+----------------+-------------------------+---------------------+-----------------+");
            }
        }

        #endregion

    }
}
