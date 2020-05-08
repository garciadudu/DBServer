using Dapper;
using DBServer.DDD.Dominio.Banco;
using DBServer.DDD.Dominio.Banco.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DBServer.DDD.Dados.Banco
{
    public class LancamentoRepository: ILancamentoRepository
    {
        private readonly IDbConnection _connection;

        public LancamentoRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> ContaCreditoExisteAsync(string Conta)
        {
            return await _connection.QueryFirstOrDefaultAsync<bool>("SELECT 1 FROM Conta WHERE ContaCodigo = @Conta", new { Conta });
        }

        public async Task<bool> ContaDebitoExisteAsync(string Conta)
        {
            return await _connection.QueryFirstOrDefaultAsync<bool>("SELECT 1 FROM Conta WHERE ContaCodigo = @Conta", new { Conta });
        }

        public async Task SalvarLancamento(Lancamento Lancamento)
        {
            await _connection.ExecuteAsync(@"INSERT INTO LANCAMENTO(ContaCreditoId, ContaDebitoId, Lancamento)
                                             VALUES (@ContaCreditoId, @ContaDebitoId, @Lancamento)",
                                             new
                                             {
                                                 ContaCreditoId = Lancamento.ContaCredito.ContaId,
                                                 ContaDebitoId = Lancamento.ContaDebito.ContaId,
                                                 Lancamento = Lancamento.LancamentoValor,
                                             });
        }
    }
}
