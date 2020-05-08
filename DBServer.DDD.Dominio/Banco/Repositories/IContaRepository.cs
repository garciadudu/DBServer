using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBServer.DDD.Dominio.Banco.Repositories
{
    public interface IContaRepository
    {
        Task<int> ObtemContaId(string Conta);

        Task SalvarConta(Conta Conta);
    }
}
