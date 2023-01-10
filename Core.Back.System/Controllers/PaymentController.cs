using Core.Back.System.Data;
using Core.Back.System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Core.Back.System.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentController : ControllerBase
	{
		private readonly DataContext _dataContext;

		public PaymentController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		[HttpGet]
		public async Task<ActionResult<List<Payment>>> GetPayment()
		{
			return Ok(await _dataContext.Payments.ToListAsync());
		}
		[HttpGet("id")]
		public async Task<ActionResult<Payment>> GetById(long id)
		{
			var getpayment = _dataContext.Payments.Find(id);
			if (getpayment == null)
			{
				return NotFound();
			}
			return getpayment;
		}
		[HttpPost]
		public async Task<ActionResult> AddPayment(Payment payment)
		{
			_dataContext.Payments.Add(payment);
			await _dataContext.SaveChangesAsync();
			return Ok(await _dataContext.Payments.ToListAsync());
		}
		[HttpPut("id")]
		public async Task<IActionResult> UpdatePayment(long id)
		{
			var ob = _dataContext.Payments;//.Update();
			await _dataContext.SaveChangesAsync();
			return Ok(ob);
		}
		/*[HttpDelete("id")]
		public async Task<IActionResult> DeletePayment(long id)
		{
			var obdel = _dataContext.Payments.SingleOrDefault(x => x.Id == id);
			*//*if (obdel == null)
				return NotFound();*/
			/*await Ok(_dataContext.Payments.ToListAsync());
			return obdel;*//*
			return ;
		}*/
	}
}
