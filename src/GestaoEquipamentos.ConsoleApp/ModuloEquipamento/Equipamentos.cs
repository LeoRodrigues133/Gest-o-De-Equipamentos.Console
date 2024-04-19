namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamento
{
    public class Equipamentos
    {
        public string nome, numeroDeSerie, fabricante;
        public DateTime dataDeFabricacao;
        public double preco;
        public int ID = novoID; // Já inicia em 1;
        private static int novoID;
        internal static int produtoEditado;

        public Equipamentos(string numeroDeSerie, int ID, string nome, DateTime dataDeFabricacao, string fabricante, double preco)
        {
            this.numeroDeSerie = numeroDeSerie;
            this.ID = GerarIdDoProduto();
            this.nome = nome;
            this.dataDeFabricacao = dataDeFabricacao;
            this.fabricante = fabricante;
            this.preco = preco;
        }

        public static int GerarIdDoProduto()
        {
            //Obrigado Thiago, eu tava me batendo nisso; <3
            return novoID++;
        }
    }
}
