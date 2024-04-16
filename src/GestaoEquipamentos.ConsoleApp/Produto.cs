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

            public Produto(string numeroDeSerie, int ID, string nome, string dataDeFabricacao, string fabricante, double preco)
            {
                this.numeroDeSerie = numeroDeSerie;
                this.ID = ID;
                this.nome = nome;
                this.dataDeFabricacao = dataDeFabricacao;
                this.fabricante = fabricante;
                this.preco = preco;
            }
        }
    }
}
