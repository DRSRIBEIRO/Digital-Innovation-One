using System;

namespace Dio.Comedia
{
    public class Comedian : EntityBase
    {
        public Comedian(int id, Genero genero, string nomeComediante, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.NomeComediante = nomeComediante;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;

        }

        private Genero Genero { get; set; }
        private string NomeComediante { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Nome Comediante: " + this.NomeComediante + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano da Comédia: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string RetornaNomeComediante(){
            return this.NomeComediante;
        }

        public int RetornaId(){
            return this.Id;
        }

        public bool RetornaExcluido(){
            return this.Excluido;
        }

        public void Excluir(){
            this.Excluido = true;
        }

    }
}