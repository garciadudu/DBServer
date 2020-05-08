using DBServer.DDD.Dominio.Banco;
using Newtonsoft.Json;
using RestSharp;
using System;
using Xunit;

namespace DBServer.DDD.Teste
{
    public class _01_ContaTest
    {
        [Fact]
        public void AddConta()
        {
            var conta = new Conta
            {
                ContaCodigo = "1",
                ContaValor = 10,
            };

            var client = new RestClient("https://localhost:44354/v1/Conta");

            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            request.Parameters.Add(new Parameter("", JsonConvert.SerializeObject(conta), ParameterType.RequestBody));

            IRestResponse response = client.Execute(request);


            Assert.True(response.StatusCode == System.Net.HttpStatusCode.Accepted);

            var conta2 = new Conta
            {
                ContaCodigo = "2",
                ContaValor = 20,
            };

            var request2 = new RestRequest(Method.POST);
            request2.AddHeader("Content-Type", "application/json");
            request2.Parameters.Add(new Parameter("", JsonConvert.SerializeObject(conta2), ParameterType.RequestBody));

            response = client.Execute(request2);

            Assert.True(response.StatusCode == System.Net.HttpStatusCode.Accepted);
        }
    }
}
