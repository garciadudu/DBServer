using DBServer.DDD.Dominio.Banco.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DBServer.DDD.Dominio.Banco.Validators
{
    public class ContaValidator : AbstractValidator<Conta>
    {
        private readonly IContaRepository _repository;

        public ContaValidator(IContaRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.ContaValor)
                .GreaterThan(0)
                .WithMessage("O Valor deve ser maior do que 0");
        }
    }
}
