namespace GestaoEquipamentos.ConsoleApp.ModuloChamado
{
    public class Chamado
    {
        public string nome, descricao;
        public DateTime prazoDoChamado;
        public double valorChamado;
        public int idChamado = novoIDChamados;
        public static int novoIDChamados;


        public Chamado(int idChamado, string nome, string descricao, DateTime dataDoChamado, double valorChamado)
        {
            this.idChamado = GerarIdChamados();
            this.nome = nome;
            this.descricao = descricao;
            this.prazoDoChamado = dataDoChamado;
            this.valorChamado = valorChamado;
        }

        public static int GerarIdChamados()
        {

            return novoIDChamados++;
        }
    }
}
