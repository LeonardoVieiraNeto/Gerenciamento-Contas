using Microsoft.AspNetCore.Mvc;
using Gerenciamento.Contas.Models;
using Gerenciamento.Contas.Services;
using Gerenciamento.Contas.Models.Interfaces;

namespace Gerenciamento.Contas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController: ControllerBase {
        
        private readonly ICustomerService _customerService;
        private readonly IFinancialTransactionService _financialTransactionService;
        private readonly IRabitMQProducer _rabitMQProducer;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService _customerService, IRabitMQProducer rabitMQProducer, ILogger<CustomerController> logger, IFinancialTransactionService financialTransactionService) {
            _customerService = _customerService;
            _rabitMQProducer = rabitMQProducer;
            _logger = logger;
            _financialTransactionService = financialTransactionService;
        }

        [HttpGet("saldo/{id}")]
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBalanceSumByCustomer(int id)
        {
            try
            {
                decimal saldo = await _customerService.GetBalanceSumByCustomer(id);

                if (saldo == 0)
                {
                    return NotFound("Cliente não encontrado ou saldo não disponível.");
                }

                return Ok(saldo);
            }
            catch (Exception ex)
            {
                // Trate exceções aqui, se necessário.
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno.");
            }
        }

        [HttpGet("ConsultaExtrato/{id}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAccountStatementInquiry(int id)
        {
            var bankStatement = _financialTransactionService.GetAccountStatementInquiry(id);

            if (bankStatement == null)
            {
                return NotFound("Extrato não recuperado"); // Cliente não encontrado
            }
            
            return Ok(bankStatement);
        }

        [HttpPost("CompraVendaAtivos")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuyingAndSellingAssets([FromBody]BuyingAndSellingAssetsDTO input) {
            
            if (input == null)
            {
                return BadRequest("Informe os dados para compra e venda e ativos.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            //send the inserted customer data to the queue and consumer will listening this data from queue
            _rabitMQProducer.SendCustomerMessage(input);

            return Ok("Operação de compra e venda submetida a um fluxo de validação assíncrono com sucesso.");
        }
    }
}