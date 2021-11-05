using System;
using System.Collections.Generic;
using Cadastro_de_Series.Interfaces;

namespace Cadastro_de_Series
{
    public class SerieRepositorio : InterRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public void Atualiza(int id, Serie conteudo)
        {
            listaSerie[id] = conteudo;
        }

        public void Excluir(int id)
        {
            listaSerie[id].Excluir(); //exclui a série
        }

        public void Insere(Serie conteudo)
        {
            listaSerie.Add(conteudo); // adiciona uma série
        }

        public List<Serie> Lista()
        {
            return listaSerie; // faz listagem da série
        }

        public int proximoID()
        {
            return listaSerie.Count; // vai para o próximo conteúdo
        }

        public Serie RetornaPorID(int id)
        {
            return listaSerie[id];// conta o id
        }
    }
}