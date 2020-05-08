using DBServer.DDD.Dominio.Banco.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DBServer.DDD.Dominio.Banco.Validators
{
    public class LancamentoValidator: AbstractValidator<Lancamento>
    {
        private readonly ILancamentoRepository _repository;

        public LancamentoValidator(ILancamentoRepository repository)
        {
            _repository = repository;


            RuleFor(x => x.ContaCredito.ContaCodigo)
                .MustAsync(SelecionadoContaCreditoAsync)
                .WithMessage("Conta Crédito inválida");

            RuleFor(x => x.ContaDebito.ContaCodigo)
                .MustAsync(SelecionadoContaDebitoAsync)
                .WithMessage("Conta Débito inválida");

            RuleFor(x => x.LancamentoValor)
                .GreaterThan(0)
                .WithMessage("O Valor deve ser maior do que 0");
        }

        private async Task<bool> SelecionadoContaCreditoAsync(string ContaCodigo, CancellationToken cancellationToken)
        {
            return await _repository.ContaCreditoExisteAsync(ContaCodigo);
        }

        private async Task<bool> SelecionadoContaDebitoAsync(string ContaCodigo, CancellationToken cancellationToken)
        {
            return await _repository.ContaDebitoExisteAsync(ContaCodigo);
        }

    }
}
