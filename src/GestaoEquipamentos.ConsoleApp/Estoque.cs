using System.Security.Cryptography.X509Certificates; // Não sei pq o systema usou isso... Me explica depois por favor.

namespace GestaoEquipamentos.ConsoleApp
{
    public class Estoque
    {
        public List<Produto> estoque = new List<Produto>();
        public int idProduto = Produto.GerarIdDoProduto();

        //public Produto(string numeroDeSerie, int ID, string nome, string dataDeFabricacao, string fabricante, double preco)

        public void Create()
        {
            //Produto novoProduto = new Produto(Program.ObterValor<string>("Serie: "),
            //                                  idProduto,
            //                                  Program.ObterValor<string>("Nome: "),
            //                                  Program.ObterValor<string>("Data de fabricação: "),
            //                                  Program.ObterValor<string>("Fabricante: "),
            //                                  Program.ObterValor<double>("Preço: "));

            Console.WriteLine("Por favor, forneça as informações do novo produto:");
            string numeroSerie = Program.ObterValor<string>("Número de Série: ");
            string nome = Program.ObterValor<string>("Nome: ");
            string dataFabricacao = Program.ObterValor<string>("Data de fabricação (DD/MM/AAAA): ");
            string fabricante = Program.ObterValor<string>("Fabricante: ");
            double preco = Program.ObterValor<double>("Preço: ");

            Produto novoProduto = new Produto(numeroSerie, idProduto, nome, dataFabricacao, fabricante, preco);


            AdicionarProduto(novoProduto);

            Console.WriteLine("Produto cadastrado com sucesso!");


        }

        #region Métodos do Create
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

        #endregion

        public void Read()
        {
            Menu.Cabecalho();

            foreach (var produto in estoque)
            {
                Console.WriteLine($"|Id: {produto.ID}".PadRight(7) +
                                  $"|Serie: {produto.numeroDeSerie}".PadRight(19) +
                                  $"|Nome: {produto.nome}".PadRight(23) +
                                  $"|Data: {produto.dataDeFabricacao}".PadRight(26) +
                                  $"|Fab: {produto.fabricante}".PadRight(19) +
                                  $"|Valor R$ {produto.preco:F}".PadRight(21) + " |");
            }

            Menu.Rodape();
        }

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
