using Core.Back.System.Data;
using Core.Back.System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

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
			var getpayment = await _dataContext.Payments.FindAsync(id);

			if (getpayment == null)
			{
				return NotFound("Payment not found");
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
		public async Task<ActionResult<List<Payment>>> UpdatePayment(Payment rew, long id)
		{
			var updatepayment = await _dataContext.Payments.FindAsync(id);
			if (updatepayment == null) { return BadRequest($"Id {id} Not found"); }
   			foreach(var item in updatepayment)
      			{
			updatepayment.Id = id;
			updatepayment.Name = rew.Name;	
			updatepayment.Description = rew.Description;
			updatepayment.Datetime = rew.Datetime;
			return Ok(updatepayment);
   			}
		}
		[HttpDelete("id")]
		public async Task<ActionResult<List<Payment>>> UpdatePayment(long id)
		{
			var payment = _dataContext.Payments.Find(id);
			if (payment == null)
			{
				return NotFound();
			}
			_dataContext.Payments.Remove(payment);
			await _dataContext.SaveChangesAsync();
			// Return the updated list of payments
			return await _dataContext.Payments.ToListAsync();
		}
	}
}




