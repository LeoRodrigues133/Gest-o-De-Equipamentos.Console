using System.Security.Cryptography.X509Certificates;

namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamento
{
    public class RepositórioEquipamentos
    {
        public List<Equipamentos> estoque = new List<Equipamentos>();
        public int idProduto = Equipamentos.GerarIdDoProduto();
        public Menu menu;


        //public Produto(string numeroDeSerie, int ID, string nome, string dataDeFabricacao, string fabricante, double preco)

        public void Create()
        {
            Console.Clear();
            #region Método antigo

            //Eu não sabia exatamente qual deveria utilizar, porém esse parece menos feio;
            //Qualquer um dos dois está funcionando;
            
            //Produto novoProduto = new Produto(Program.ObterValor<string>("Serie: "),
            //                                  idProduto,
            //                                  Program.ObterValor<string>("Nome: "),'  
            //                                  Program.ObterValor<string>("Data de fabricação: "),
            //                                  Program.ObterValor<string>("Fabricante: "),
            //                                  Program.ObterValor<double>("Preço: "));

            #endregion

            Console.WriteLine("Por favor, forneça as informações do novo produto:");

            string numeroSerie = Program.ObterValor<string>("Número de Série: ");
            string nome = Program.ObterValor<string>("Nome: ");
            DateTime dataFabricacao = Program.ObterValor<DateTime>("Data de fabricação (DD/MM/AAAA): ");
            string fabricante = Program.ObterValor<string>("Fabricante: ");
            double preco = Program.ObterValor<double>("Preço: ");

            Equipamentos novoProduto = new Equipamentos(numeroSerie, idProduto, nome, dataFabricacao, fabricante, preco);

            AdicionarProduto(novoProduto);

            Menu.ModificarCor("Sucesso", "Produto cadastrado com sucesso!\n");

        }

        #region Métodos do Create
        public void AdicionarProduto(Equipamentos novoProduto)
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
            Console.Clear();
            Menu.Cabecalho("Equipamento");
            if (VerificarEstoque() == false)
            {
                foreach (var produto in estoque)
                {
                    Console.WriteLine($"|Id: {produto.ID}".PadRight(7) +
                                      $"|Serie: {produto.numeroDeSerie}".PadRight(19) +
                                      $"|Nome: {produto.nome}".PadRight(23) +
                                      $"|Data: {produto.dataDeFabricacao.ToShortDateString()}".PadRight(26) +
                                      $"|Fab: {produto.fabricante}".PadRight(19) +
                                      $"|Valor R$ {produto.preco:F}".PadRight(21) + " |");
                }
            }

            Menu.Rodape();
        }
        #region Metodos do Read
        private bool VerificarEstoque()
        {
            int contagem = estoque.Count<Equipamentos>();

            if (contagem > 0)
                return false;

            Menu.ModificarCor("Erro", "\t\t\t\t\t\tO estoque está vazio!\n");
            return true;
        }
        #endregion

        public void Update()
        {
            Console.Clear();

            Read();

            int idSelecao = Program.ObterValor<int>("Digite o ID do produto desejado: ");

            Equipamentos produtoEditado = estoque.FirstOrDefault(idDoProduto => idDoProduto.ID == idSelecao)!;

            if (produtoEditado != null)
            {
                SelecionarCampoDeEdicao(produtoEditado);
                Read();

                Menu.ModificarCor("Sucesso", "Produto atualizado com sucesso!\n");
            }
            else
            {
                Menu.ModificarCor("Aviso", "Produto não encontrado.\n");
            }
        }

        #region Metodos do Update
        private void SelecionarCampoDeEdicao(Equipamentos produtoEditado)
        {
            int opcao = Menu.ExibirMenuEdicao();

            switch (opcao)
            {
                case 1:
                    string novoNumeroDeSerie = Program.ObterValor<string>("Serie: ");

                    EditarSerial(produtoEditado, novoNumeroDeSerie);
                    break;

                case 2:
                    string novoNome = Program.ObterValor<string>("Nome: ");

                    EditarNome(produtoEditado, novoNome);
                    break;

                case 3:
                    DateTime novaDataDeFabricacao = Program.ObterValor<DateTime>("Data de fabricação: ");

                    EditarData(produtoEditado, novaDataDeFabricacao);
                    break;

                case 4:
                    string novoFabricante = Program.ObterValor<string>("Fabricante: ");

                    EditarFabricante(produtoEditado, novoFabricante);
                    break;

                case 5:
                    double novoPreco = Program.ObterValor<double>("Preco:");

                    EditarPreco(produtoEditado, novoPreco);
                    break;
            }
        }

        private bool EditarPreco(Equipamentos produtoEditado, double novoPreco)
        {
            if (novoPreco == null || novoPreco == 0)
                return false;

            produtoEditado.preco = novoPreco;

            return true;
        }

        private bool EditarFabricante(Equipamentos produtoEditado, string novoFabricante)
        {
            if (novoFabricante == null || novoFabricante == "")
                return false;
            produtoEditado.fabricante = novoFabricante;

            return true;
        }

        private bool EditarData(Equipamentos produtoEditado, DateTime novaDataDeFabricacao)
        {

            if (novaDataDeFabricacao == null)
                return false;

            produtoEditado.dataDeFabricacao = novaDataDeFabricacao;

            return true;
        }

        private bool EditarNome(Equipamentos produtoEditado, string novoNome)
        {

            if (novoNome == null || novoNome == "")
                return false;

            produtoEditado.nome = novoNome;

            return true;
        }

        private bool EditarSerial(Equipamentos produtoEditado, string novoNumeroDeSerie)
        {
            if (novoNumeroDeSerie == null || novoNumeroDeSerie == "")
                return false;


            produtoEditado.numeroDeSerie = novoNumeroDeSerie;

            return true;
        }
        #endregion

        public void Delete()
        {
            Console.Clear();
            Read();

            int idSelecao = Program.ObterValor<int>("Digite o ID do produto desejado: ");

            Equipamentos produtoDeletado = estoque.FirstOrDefault(idDoProduto => idDoProduto.ID == idSelecao)!; // é a bença isso.

            if (produtoDeletado != null)
            {
                estoque.Remove(produtoDeletado);
                Read();
                Menu.ModificarCor("Erro", "Produto removido com sucesso!\n");


            }
            else
            {
                Menu.ModificarCor("Aviso", "Produto não encontrado.\n");

            }
        }

    }
}
