using System;
using System.Collections.Generic;
using System.Text;

namespace DBServer.DDD.Dominio.Banco
{
    public class Lancamento
    {
        public Conta ContaCredito { get; set; }
        public Conta ContaDebito { get; set; }
        public decimal LancamentoValor { get; set; }
    }
}
