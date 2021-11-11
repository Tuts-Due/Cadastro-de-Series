using System;
using Cadastro_de_Series.Classes;


namespace Cadastro_de_Series
{
    public class Serie : Base 
    {
      
        //Atributos
        private Genero Genero {get;set;}
        private string Titulo {get;set;}
        private string Descricao {get;set;}
        private int Ano {get;set;}
        private int Temporada {get;set;}
        private bool Excluido {get;set;}

//Métodos
        public Serie(int id, Genero genero, string titulo, int ano, string descricao, int temporada)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Temporada = temporada;
            this.Excluido = false;
        }
           public override string ToString()
           {
               string retorno = " ";
               retorno += "Gênero: " + this.Genero + Environment.NewLine;
               retorno += "Título: " + this.Titulo + Environment.NewLine;
               retorno += "Descrição: " + this.Descricao + Environment.NewLine;
               retorno += "Ano de Lançamento: " + this.Ano + Environment.NewLine;
               retorno += "Temporadas" + this.Temporada + Environment.NewLine;
               retorno += "Excluído: " + this.Excluido;
               return retorno;
           }
      
      public string retornaTitulo()
      {
          return this.Titulo;
      }
      public int retornaId()
      {
          return this.Id;
      }
      public int retornaTemporada()
      {
          return this.Temporada;
      }

       public bool retornaExcluido()
      {
          return this.Excluido;
      }
      public void Excluir(){
          this.Excluido = true;
      }
    }
}