using System.Collections.Generic;

namespace Cadastro_de_Series.Interfaces
{
    public interface InterRepositorio <T>
    {
        List<T> Lista();
        T RetornaPorID(int id);

        void Insere(T conteudo);
        void Excluir(int id);
        void Atualiza(int id, T  conteudo);
        int proximoID();
    }
}