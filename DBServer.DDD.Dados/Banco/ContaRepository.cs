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
    public class ContaRepository: IContaRepository
    {
        private readonly IDbConnection _connection;

        public ContaRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task SalvarConta(Conta Conta)
        {
            await _connection.ExecuteAsync(@"INSERT INTO CONTA(CONTACODIGO, CONTAVALOR)
                                             VALUES (@ContaCodigo, @ContaValor)",
                                             new { ContaCodigo = Conta.ContaCodigo,
                                                 ContaValor = Conta.ContaValor
                                             });
        }

        public async Task<int> ObtemContaId(string Conta)
        {
            return await _connection.QueryFirstOrDefaultAsync<int>("SELECT ContaId FROM Conta WHERE ContaCodigo = @Conta",
                new { Conta });

        }
    }
}
