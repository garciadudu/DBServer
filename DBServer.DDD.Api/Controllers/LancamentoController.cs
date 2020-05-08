using System.Threading.Tasks;
using DBServer.DDD.Dominio.Banco;
using DBServer.DDD.Dominio.Banco.Repositories;
using DBServer.DDD.Dominio.Banco.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DBServer.DDD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentoController : ControllerBase
    {
        
        [Route("~/v1/Lancamento/Lancar")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> LancarAsync([FromServices] ILancamentoRepository repository, [FromServices] IContaRepository contaRepository, [FromBody] Lancamento request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var lancamento = new Lancamento
            {
                ContaCredito = new Conta
                {
                    ContaCodigo = request.ContaCredito.ContaCodigo,
                    ContaId = await contaRepository.ObtemContaId(request.ContaCredito.ContaCodigo),
                },
                ContaDebito = new Conta
                {
                    ContaCodigo = request.ContaDebito.ContaCodigo,
                    ContaId = await contaRepository.ObtemContaId(request.ContaDebito.ContaCodigo),
                },
                LancamentoValor = request.LancamentoValor
            };

            var validator = new LancamentoValidator(repository);
            var validationResult = await validator.ValidateAsync(lancamento);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return BadRequest(ModelState);
            }

            await repository.SalvarLancamento(lancamento);

            return Accepted();
        }
    }
}