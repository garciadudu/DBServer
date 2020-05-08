using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBServer.DDD.Dominio.Banco.Repositories
{
    public interface ILancamentoRepository
    {
        Task<bool> ContaCreditoExisteAsync(string Conta);
        Task<bool> ContaDebitoExisteAsync(string Conta);

        Task SalvarLancamento(Lancamento lancamento);
    }
}
