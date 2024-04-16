using System.Security.Cryptography.X509Certificates;

namespace GestaoEquipamentos.ConsoleApp
{
    public class Estoque
    {
        public List<Produto> estoque = new List<Produto>();
        public int idProduto = Produto.GerarIdDoProduto();

        //public Produto(string numeroDeSerie, int ID, string nome, string dataDeFabricacao, string fabricante, double preco)

        public void Create()
        {
            Produto novoProduto = new Produto(Program.ObterValor<string>("Serie: "),
                                              idProduto,
                                              Program.ObterValor<string>("Nome: "),
                                              Program.ObterValor<string>("Data de fabricação: "),
                                              Program.ObterValor<string>("Fabricante: "),
                                              Program.ObterValor<double>("Preço: "));

            AdicionarProduto(novoProduto);

            Console.WriteLine("Produto cadastrado com sucesso!");


        }

        private void AdicionarProduto(Produto novoProduto)
        {

            estoque.Add(novoProduto);
            #region Comment to Rech
            //Eu ia fazer do jeito mais difícil...
            //Mas quis manter minha sanidade :)


            //estoque[0] = ($"{novoProduto.numeroDeSerie}{novoProduto.ID}".PadRight(20) +
            //              $"|{novoProduto.nome}".PadRight(20) +
            //              $"|{novoProduto.dataDeFabricacao}".PadRight(22) +
            //              $"|{novoProduto.fabricante}".PadRight(15) +
            //              $"|R$ {novoProduto.preco}".PadRight(20) + " |");

            //for (int i = estoque.Length - 1; i > 0; i--)
            //{
            //    estoque[i] = estoque[i - 1];
            //}
            #endregion
        }



        public void Read()
        {
            Cabecalho();

            foreach (var produto in estoque)
            {
                Console.WriteLine($"|Id: {produto.ID}".PadRight(7) +
                                  $"|Serie: {produto.numeroDeSerie}".PadRight(19) +
                                  $"|Nome: {produto.nome}".PadRight(23) +
                                  $"|Data: {produto.dataDeFabricacao}".PadRight(26) +
                                  $"|Fab: {produto.fabricante}".PadRight(19) +
                                  $"|Valor R$ {produto.preco}".PadRight(21) + " |");
            }

            Rodape();
        }
        #region Geradores de Tabela
        private static void Rodape()
        {
            Console.WriteLine("+------+------------------+----------------------+-------------------------+------------------+---------------------+");
        }

        private static void Cabecalho()
        {
            Console.WriteLine("+------+------------------+----------------------+-------------------------+------------------+---------------------+");
            Console.WriteLine("|  ID  |      Série       |    Nome do Produto   |   Data de Fabricação    |    Fabricante    |  Preço do Produto   |");
            Console.WriteLine("+------+------------------+----------------------+-------------------------+------------------+---------------------+");
        }
        #endregion
        public void Update()
        {
            Read();


            int idSelecao = Program.ObterValor<int>("Digite o ID do produto desejado: ");

            Produto produtoEditado = estoque.FirstOrDefault(idDoProduto => idDoProduto.ID == idSelecao)!;

            if (produtoEditado != null)
            {
                EditarSerial(produtoEditado);

                EditarNome(produtoEditado);

                EditarData(produtoEditado);

                EditarFabricante(produtoEditado);

                EditarPreco(produtoEditado);

                Read();
            }

        }
        #region Metodos do Update
        private void EditarPreco(Produto produtoEditado)
        {
            double novoPreco = Program.ObterValor<double>("Preco:");

            if (novoPreco != null && novoPreco != 0)
                produtoEditado.preco = novoPreco;
        }

        private void EditarFabricante(Produto produtoEditado)
        {
            string novoFabricante = Program.ObterValor<string>("Fabricante: ");

            if (novoFabricante != null && novoFabricante != "")
                produtoEditado.fabricante = novoFabricante;
        }

        private void EditarData(Produto produtoEditado)
        {
            string novaDataDeFabricacao = Program.ObterValor<string>("Data de fabricação: ");

            if (novaDataDeFabricacao != null && novaDataDeFabricacao != "")
                produtoEditado.dataDeFabricacao = novaDataDeFabricacao;
        }

        private void EditarNome(Produto produtoEditado)
        {
            string novoNome = Program.ObterValor<string>("Nome: ");

            if (novoNome != null && novoNome != "")
                produtoEditado.nome = novoNome;
        }

        private void EditarSerial(Produto produtoEditado)
        {
            string novoNumeroDeSerie = Program.ObterValor<string>("Serie: ");

            if (novoNumeroDeSerie != null && novoNumeroDeSerie != "")
                produtoEditado.numeroDeSerie = novoNumeroDeSerie;
        }
        #endregion
        public void Delete()
        {
            Read();

            int idSelecao = Program.ObterValor<int>("Digite o ID do produto desejado: ");

            Produto produtoDeletado = estoque.FirstOrDefault(idDoProduto => idDoProduto.ID == idSelecao)!; // é a bença isso.

            if (produtoDeletado != null)
            {
                estoque.Remove(produtoDeletado);
                Read();
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }
    }
}
