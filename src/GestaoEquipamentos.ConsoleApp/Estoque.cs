namespace GestaoEquipamentos.ConsoleApp
{
    internal partial class Program
    {
        public class Estoque
        {
            public string[] estoque = new string[100];
            public int idProduto;
            public Produto item;

            //public Produto(string numeroDeSerie, int ID, string nome, string dataDeFabricacao, string fabricante, double preco)

            public void Create()
            {
                Produto novoProduto = new Produto(ObterValor<string>("Serie: "),
                                                  ObterValor<int>("ID: "),
                                                  ObterValor<string>("Nome: "),
                                                  ObterValor<string>("Data de fabricação: "),
                                                  ObterValor<string>("Fabricação: "),
                                                  ObterValor<double>("Preço: "));

                estoque[0] = ($"{novoProduto.numeroDeSerie}{novoProduto.ID}".PadRight(20) +
                              $"|{novoProduto.nome}".PadRight(20) +
                              $"|{novoProduto.dataDeFabricacao}".PadRight(22) +
                              $"|{novoProduto.fabricante}".PadRight(15) +
                              $"|R$ {novoProduto.preco}".PadRight(20) + " |");

                for (int i = estoque.Length - 1; i > 0; i--)
                {
                    estoque[i] = estoque[i - 1];
                }

                Console.WriteLine("Produto cadastrado com sucesso!");

                estoque[0] = "Serie:".PadRight(20) +
                             "|Nome do produto:".PadRight(20) +
                             "|Data de fabricação:".PadRight(22) +
                             "|Fabricante:".PadRight(15) +
                             "|Preço do produto:".PadRight(20) + " |";



            }
            public void Read()
            {
                string Linha = "+----------------------------------------------------------------------------------------------------+";
                for (int i = 0; i < estoque.Length; i++)
                {
                    if (estoque[i] != null)
                    {
                        Console.WriteLine($"{Linha}\n{estoque[i]}");
                    }
                }
            }

            public void Update()
            {

            }

            public void Delete()
            {

            }
        }

    }

}
