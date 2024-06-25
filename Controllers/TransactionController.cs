using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingTest.Dto.Transaction;
using BankingTest.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankingTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository repo;

        public TransactionController(ITransactionRepository repository){
            this.repo = repository;
        }

        [HttpPost("withdraw")]
        public IActionResult Withdraw([FromBody] WithdrawDto withdrawDto){
            try{
                var transaction = repo.StoreWithdraw(withdrawDto);
                if(transaction == null){
                    return BadRequest(new{Status = "Failed", Message = "Account does not exist"});
                }
                return Ok(new{ Status = "Success", Message = "Transaction Successfully", Data = transaction});
            }
            catch(Exception ex){
                return BadRequest(new{Status = "Failed", Message = ex.Message});
            }
        }
        [HttpPost("deposit")]
        public IActionResult Deposit([FromBody] DepositDto depositDto){
            try{
                var transaction = repo.StoreDeposit(depositDto);
                if(transaction == null){
                    return BadRequest(new{Status = "Failed", Message = "Account does not exist"});
                }
                return Ok(new{ Status = "Success", Message = "Transaction Success", Data = transaction});
            }
            catch(Exception ex){
                return BadRequest(new{Status = "Failed", Message = ex.Message});
            }
        }

        [HttpGet]
        public IActionResult GetTransaction(){
            var transaction = repo.GetAllTransactions();
            return Ok(new{ Status = "Success", Data = transaction});
        }
        [HttpGet("{customerId}")]
        public IActionResult GetTransaction([FromRoute] Guid customerId){
            var transaction = repo.GetTransactionByCustomer(customerId);
            if(transaction == null){
                return BadRequest(new{Status = "Failed", Message = "Customer record does not exist"});
            }
            return Ok(new{ Status = "Success", Data = transaction});
        }
    }
}