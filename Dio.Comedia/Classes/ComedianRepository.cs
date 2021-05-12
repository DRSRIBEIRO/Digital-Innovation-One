using System.Collections.Generic;
using Dio.Comedia.Interfaces;

namespace Dio.Comedia
{
    public class ComedianRepository : IRepository<Comedian>
    {
        private List<Comedian> listaComediantes = new List<Comedian>();

        public void Atualiza(int id, Comedian entidade)
        {
            listaComediantes[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaComediantes[id].Excluir();
        }
 
        public void Insere(Comedian entidade)
        {
            listaComediantes.Add(entidade);
        }

        public List<Comedian> Lista()
        {
            return listaComediantes;
        }

        public int ProximoId()
        {
            return listaComediantes.Count;
        }

        public Comedian RetornaPorId(int id)
        {
            return listaComediantes[id];
        }
    }
}