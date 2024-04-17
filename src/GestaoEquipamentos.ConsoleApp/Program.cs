namespace GestaoEquipamentos.ConsoleApp
{
    internal partial class Program
    {
        private static Produto novoProduto;

        static void Main(string[] args)
        {
            Console.WriteLine("Gerenciamento de Equipamentos, Academia de Programação!\n");

            Estoque estoque = new Estoque();


            while (true)
            {
                int opcao = ObterValor<int>("Selecione uma opção do menu: \n" +
                                            "1 - Adicionar um produto.\n" +
                                            "2 - Ver lista de produtos.\n" +
                                            "3 - Editar um produto.\n" +
                                            "4 - Deletar um produto.");

                switch (opcao)
                {

                    case 1:
                        Console.Clear();
                        Console.WriteLine("Adicione um produto.");
                        estoque.Create();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Ver lista de produtos.");
                        estoque.Read();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Editar um produto.");
                        estoque.Update();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Deletar um produto.");
                        estoque.Delete();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Selecione uma opção.");
                        break;
                }
            }
        }

        #region Métodos da Main
        public static T ObterValor<T>(string texto)
        {
            Console.WriteLine(texto);

            string input = Console.ReadLine();

            try
            {
                return (T)Convert.ChangeType(input, typeof(T));
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato inválido!");
                return ObterValor<T>(texto);
            }
        }
        #endregion

    }

}
