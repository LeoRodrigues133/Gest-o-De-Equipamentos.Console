//using GestaoEquipamentos.ConsoleApp.ModuloEquipamentos;

//namespace GestaoEquipamentos.ConsoleApp.ModuloChamados
//{
//    public class RepositorioChamados
//    {
//        public List<Chamado> suporte = new List<Chamado>();
//        public int idChamado = Chamado.GerarIdChamados();

//        //public Chamado(int idChamados, string nome, string descricao, string dataDoChamado, double valorChamado)

//        public void Create() {
//            string nome = Program.ObterValor<string>("Nome do Chamado: ");
//            string descricao = Program.ObterValor<string>("Descrição do chamado: ");
//            string dataDoChamado = Program.ObterValor<string>("Data de criação do chamado: ");
//            double valorChamado = Program.ObterValor<double>("Valor do chamado: ");

//                Chamado novoChamado = new Chamado(idChamado, nome, descricao, dataDoChamado, valorChamado);
//        }
//        private void AdicionarChamado(Chamado chamado)
//        {
//            suporte.Add(chamado);
//        }

//        public void Read() {

//            Menu.CabecalhoChamado();
//            foreach( var chamado in suporte)
//            {

//                Console.WriteLine($"|Id: {chamado.idChamado}".PadRight(7) +
//                                  $"|Nome: {chamado.nome}".PadRight(23) +
//                                  $"|Descrição: {chamado.descricao}".PadRight(19) +
//                                  $"|Data: {chamado.dataDoChamado}".PadRight(26) +
//                                  $"|Valor R$ {chamado.valorChamado:F}".PadRight(21) + " |");
//            }
//            Menu.Rodape();
//        }
//        public void Update() { }
//        public void Delete() { }


//    }
//}
