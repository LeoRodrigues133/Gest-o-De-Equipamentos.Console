using GestaoEquipamentos.ConsoleApp.ModuloChamado;
using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoEquipamentos.ConsoleApp
{
    public class Menu
    {
        public RepositórioEquipamentos estoque;
        public RepositorioChamados suporte;
        public Equipamento produtoEditado;

        public Menu(RepositórioEquipamentos estoque, RepositorioChamados suporte)
        {
            this.estoque = estoque;
            this.suporte = suporte;
        }

        public string EscolherMenu()
        {
            Console.Clear();
            Console.WriteLine("Gerenciamento de Equipamentos | Academia de Programação 2024!\n");

            ModificarCor("x","Escolha qual sistema de cadastro deseja?");
            ModificarCor("x", "\n\n\t1 - ");
            ModificarCor("", "Gestão de Produtos"); 
            ModificarCor("x", "\n\n\t2 - ");
            ModificarCor("", "Suporte técnico \n\n");
            int seletor = Program.ObterValor<int>("Digite: ");

            if (seletor == 1)
            return "Equipamento";
            else if (seletor == 2)
                return "";

            else return EscolherMenu();
        }

        public void ExibirMenu()
        {
            bool continuar = true;

            string tipo = EscolherMenu();
            while (continuar)
            {
                while (tipo == "Equipamento")
                {
                    ExibirMenuProdutos();
                    continuar = SelecionarAcao(continuar, tipo);
                }
                while (tipo == "")
                {

                    ExibirMenuChamados();
                    continuar = SelecionarAcao(continuar, tipo);
                }
                //if (continuar)
                //{
                //    Console.WriteLine("Pressione para continuar...");
                //    Console.ReadKey();
                //}
            }
        }

        public void ExibirMenuChamados()
        {
            Console.Clear();
            Console.WriteLine("Bem-vindo ao Suporte!\n");
            Console.WriteLine("Escolha uma opção:");

            ModificarCor("x", "1 - ");
            ModificarCor("", "Cadastrar novo Chamado\n");
            ModificarCor("x", "2 - ");
            ModificarCor("", "Listar todos os Chamados\n");
            ModificarCor("x", "3 - ");
            ModificarCor("", "Atualizar um Chamado existente\n");
            ModificarCor("x", "4 - ");
            ModificarCor("", "Remover um Chamado\n");
            ModificarCor("x", "0 - ");
            ModificarCor("Erro", "Sair\n\n");
        }

        public void ExibirMenuProdutos()
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
            ModificarCor("x", "0 - ");
            ModificarCor("Erro", "Sair\n\n");
        }

        public bool SelecionarAcao(bool continuar, string tipo)
        {
            int opcao = Program.ObterValor<int>("Digite o número da opção desejada: ");
            if (tipo == "Equipamento")
            {
                switch (opcao)
                {
                    case 0:
                        ExibirMenu();
                        break;
                    case 1:
                        estoque.Create();
                        break;
                    case 2:
                        estoque.Read();
                        break;
                    case 3:
                        estoque.Update();
                        break;
                    case 4:
                        estoque.Delete();
                        break;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            }
            else if (tipo == "")
            {
                switch (opcao)
                {
                    case 0:
                        ExibirMenu();
                        break;
                    case 1:
                        suporte.Create();
                        break;
                    case 2:
                        suporte.Read();
                        break;
                    case 3:
                        suporte.Update();
                        break;
                    case 4:
                        suporte.Delete();
                        break;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            }

            return continuar;
        }

        public static int ExibirMenuEdicao(string tipo)
        {
            if (tipo == "Equipamento")
            {
                int opcao = Program.ObterValor<int>("Digite qual campo deseja atualizar: \n" +
                                    "1 - Serial\n" +
                                    "2 - Nome\n" +
                                    "3 - Data de fabricação\n" +
                                    "4 - Fabricante\n" +
                                    "5 - Preço\n" +
                                    "0 - Sair\n");
                return opcao;
            }
            else
            {
                int opcao = Program.ObterValor<int>("Digite qual campo deseja atualizar: \n" +
                    "1 - Nome\n" +
                    "2 - Descrição\n" +
                    "3 - Data do chamado\n" +
                    "4 - Valor\n" +
                    "0 - Sair\n");
                return opcao;
            }

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
                case "x":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
            Console.Write(resposta);
            Console.ResetColor();
        }

        #region Construtores de String
        public static void Rodape(string tipo)
        {
            if (tipo == "Equipamento")
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("+------+------------------+----------------------+-------------------------+------------------+---------------------+");
            }
            else
            {
                Console.WriteLine("+------+----------------+---------------------------------+-------------------+-------------+");
            }
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
                Console.Write("+------+----------------+---------------------------------+-------------------+-------------+\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("|  ID  |");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("      Nome      |            Descrição            |  Data do Chamado  |    Valor    |");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("+------+----------------+---------------------------------+-------------------+-------------+");
            }
        }

        #endregion

    }
}