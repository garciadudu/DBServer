using System;
using System.Collections.Generic;
using System.Text;

namespace DBServer.DDD.Dominio.Banco
{
    public class Conta
    {
        public int ContaId { get; set; }
        public string ContaCodigo { get; set; }
        public decimal ContaValor { get; set; }
    }

}
