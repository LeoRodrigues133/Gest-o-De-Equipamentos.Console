using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoEquipamentos.ConsoleApp.ModuloChamado;

namespace GestaoEquipamentos.ConsoleApp.ModuloChamado
{
    public class RepositorioChamados
    {
        public List<Chamado> suporte = new List<Chamado>();
        public int idChamado = Chamado.GerarIdChamados();

        //public Chamado(int idChamados, string nome, string descricao, string dataDoChamado, double valorChamado)

        public void Create()
        {
            Console.WriteLine("Por favor, forneça as informações do chamado: ");

            string nome = Program.ObterValor<string>("Titulo do Chamado: ");
            string descricao = Program.ObterValor<string>("Descrição do chamado: ");
            DateTime dataDoChamado = Program.ObterValor<DateTime>("Prazo do chamado (DD/MM/AAAA): ");
            double valorChamado = Program.ObterValor<double>("Valor do chamado: ");

            Chamado novoChamado = new Chamado(idChamado, nome, descricao, dataDoChamado, valorChamado);
            AdicionarChamado(novoChamado);
            Menu.ModificarCor("Sucesso", "Chamado cadastrado com sucesso!\n");

        }
        private void AdicionarChamado(Chamado chamado)
        {
            suporte.Add(chamado);
        }

        public void Read()
        {

            Menu.Cabecalho("");
            if (VerificarEstoque() == false)
            {
                foreach (var chamado in suporte)
                {

                    Console.WriteLine($"|Id: {chamado.idChamado}".PadRight(7) +
                                      $"| {chamado.nome}".PadRight(17) +
                                      $"| {chamado.descricao}".PadRight(34) +
                                      $"| {chamado.prazoDoChamado.ToShortDateString()}".PadRight(20) +
                                      $"|R$ {chamado.valorChamado:F}".PadRight(13) + " |");
                }
            }
            Menu.Rodape("");
            Console.WriteLine("Pressione para continuar...");
            Console.ReadKey();

        }

        #region Metodos do Read
        private bool VerificarEstoque()
        {
            int contagem = suporte.Count<Chamado>();

            if (contagem > 0)
                return false;

            Menu.ModificarCor("Erro", "\t\t\t\t\t[Não há Chamados!]\n");
            return true;
        }
        #endregion

        public void Update()
        {
            Console.Clear();

            Read();

            int idSelecao = Program.ObterValor<int>("Digite o ID do produto desejado: ");

            Chamado chamadoEditado = suporte.FirstOrDefault(IdDoChamado => IdDoChamado.idChamado == idSelecao)!;

            if (chamadoEditado != null)
            {
                SelecionarCampoDeEdicao(chamadoEditado);
                Read();

                Menu.ModificarCor("Sucesso", "Chamado atualizado com sucesso!\n");
            }
            else
            {
                Menu.ModificarCor("Aviso", "Chamado não encontrado.\n");
            }
        }

        #region Metodos do Update

        private void SelecionarCampoDeEdicao(Chamado chamadoEditado)
        {
            int opcao = Menu.ExibirMenuEdicao("Equipamento");

            switch (opcao)
            {
                case 1:
                    string novoNome = Program.ObterValor<string>("Nome: ");

                    EditarNome(chamadoEditado, novoNome);
                    break;

                case 2:
                    string novaDescricao = Program.ObterValor<string>("Data de fabricação: ");

                    EditarDescricao(chamadoEditado, novaDescricao);
                    break;

                case 3:
                    DateTime novoPrazo = Program.ObterValor<DateTime>("Data de fabricação: ");

                    EditarPrazo(chamadoEditado, novoPrazo);
                    break;

                case 4:
                    double novoPreco = Program.ObterValor<double>("Preco:");

                    EditarPreco(chamadoEditado, novoPreco);
                    break;
                case 0:
                    Menu.ModificarCor("Aviso", "Nenhuma alteração foi feita!");
                    break;


            }
        }

        private bool EditarNome(Chamado chamadoEditado, string novoNome)
        {
            if (novoNome == null) 
                return false;
            chamadoEditado.nome = novoNome;
            return true;
        }

        private bool EditarDescricao(Chamado chamadoEditado, string novoDescricao)
        {
            if (novoDescricao == null) return false;

            chamadoEditado.descricao = novoDescricao;
            return true;
        }

        private bool EditarPrazo(Chamado chamadoEditado, DateTime novoPrazo)
        {
            if (novoPrazo == null)
                return false;

            chamadoEditado.prazoDoChamado = novoPrazo;
            return true;
        }

        private bool EditarPreco(Chamado chamadoEditado, double novoPreco)
        {
            if(novoPreco == null)
                return false;

            chamadoEditado.valorChamado = novoPreco;
            return true;
        }

        #endregion

        public void Delete() {

            int idSelecao = Program.ObterValor<int>("Digite o ID para atualizar o Chamado: ");

            Chamado chamadoRemovido = suporte.FirstOrDefault(idDoChamada => idDoChamada.idChamado == idSelecao);

            if (chamadoRemovido == null)
            {
                Menu.ModificarCor("Aviso", "Chamado não encontrado.\n");

            }
            else
            {
                suporte.Remove(chamadoRemovido);
                Read();
                Menu.ModificarCor("Erro", "Chamado removido com sucesso!\n");
            }
        }


    }
}
