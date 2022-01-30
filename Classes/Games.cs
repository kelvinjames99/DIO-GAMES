using DIO_GAMES.Enums;

namespace DIO_GAMES.Classes
{
    public class Games : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }
        private string Devs { get; set; }

        public Games(int id, Genero genero, string titulo, string descricao, int ano, string devs)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
            this.Devs = devs;
        }

        public override string ToString()
        {
            string texto = "";
            texto += $"Gênero: {this.Genero} {Environment.NewLine}";
            texto += $"Titulo: {this.Titulo} {Environment.NewLine}";
            texto += $"Descrição: {this.Descricao} {Environment.NewLine}";
            texto += $"Ano de lançamento: {this.Ano} {Environment.NewLine}";
            texto += $"Excluído: {(this.Excluido ? "Sim" : "Não")} {Environment.NewLine}";
            texto += $"Desenvolvedora: {this.Devs} {Environment.NewLine}";
            return texto;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

    }
}