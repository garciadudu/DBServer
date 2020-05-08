using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ContaController : ControllerBase
    {

        [Route("~/v1/conta")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(ModelStateDictionary), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CriaConta([FromServices] IContaRepository repository, [FromBody] Conta request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var conta = new Conta
            {
                ContaCodigo = request.ContaCodigo,
                ContaValor = request.ContaValor
            };

            var validator = new ContaValidator(repository);
            var validationResult = await validator.ValidateAsync(conta);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return BadRequest(ModelState);
            }

            await repository.SalvarConta(conta);

            return Accepted();
        }

    }
}