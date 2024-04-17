namespace GestaoEquipamentos.ConsoleApp
{
    internal partial class Program
    {
    public class Produto
    {
            public int ID;
        public string nome, numeroDeSerie, fabricante;
        public string dataDeFabricacao;
        public double preco;
        public int ID = novoID; // Já inicia em 1;
        private static int novoID;
        public Produto(string numeroDeSerie, int ID, string nome, string dataDeFabricacao, string fabricante, double preco)
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
