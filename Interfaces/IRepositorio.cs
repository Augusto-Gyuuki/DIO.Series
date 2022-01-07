using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series.Interfaces
{
    internal interface IRepositorio<T>
    {
        List<T> Lista();

        T RetornaPorId(int id);

        void Insere(T entidate);

        void Excluir(int id);

        void Atualizar(int id, T entidade);

        int ProximoId();
    }
}
