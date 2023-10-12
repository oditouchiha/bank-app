
using BankApp.Exceptions;
using BankApp.Models;
using BankApp.Services.Lotteries;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers;

public class LotteryController : BaseController
{
    readonly LotteryService _lotteryService;

    public LotteryController(LotteryService lotteryService)
    {
        _lotteryService = lotteryService;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Lottery>>> Get()
    {
        try
        {
            var lotteries = await _lotteryService.Get().ConfigureAwait(false);
            return lotteries.ToList();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Lottery>> GetById(int id)
    {
        try
        {
            return await _lotteryService.GetById(id).ConfigureAwait(false);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("account/{accountId}")]
    public async Task<ActionResult<Lottery>> GetByAccountId(int accountId)
    {
        try
        {
            var lottery = await _lotteryService.GetByAccountId(accountId).ConfigureAwait(false);
            if (lottery == null)
            {
                return NotFound();
            }
            else
            {
                return lottery;
            }
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(LotteryCreateSchema request)
    {
        return await _lotteryService.Create(request).ConfigureAwait(false);
    }

    [HttpPost("account/{accountId}")]
    public async Task<ActionResult> CreateAccount(int accountId, [FromBody] LotteryUpdateAccountSchema request)
    {
        if (accountId != request.accountId)
        {
            return BadRequest();
        }

        try
        {
            await _lotteryService.CreateAccount(request).ConfigureAwait(false);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("account/{accountId}")]
    public async Task<ActionResult> DeleteAccount(int accountId, [FromBody] LotteryUpdateAccountSchema request)
    {
        if (accountId != request.accountId)
        {
            return BadRequest();
        }

        try
        {
            await _lotteryService.DeleteAccount(request).ConfigureAwait(false);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

}
