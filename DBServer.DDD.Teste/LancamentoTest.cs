using DBServer.DDD.Dominio.Banco;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DBServer.DDD.Teste
{
    public class _02_LancamentoTest
    {
        [Fact]
        public void AddLancamento()
        {
            var lancamento = new Lancamento
            {
                ContaCredito = new Conta
                {
                    ContaCodigo = "1"
                },
                ContaDebito = new Conta
                {
                    ContaCodigo = "2"
                },
                LancamentoValor = 200,
            };

            var client = new RestClient("https://localhost:44354/v1/Lancamento/Lancar");

            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            request.Parameters.Add(new Parameter("", JsonConvert.SerializeObject(lancamento), ParameterType.RequestBody));

            IRestResponse response = client.Execute(request);


            Assert.True(response.StatusCode == System.Net.HttpStatusCode.Accepted);
        }

    }
}
