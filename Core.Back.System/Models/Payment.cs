namespace Core.Back.System.Models
{
	public class Payment
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Type { get; set; }
		public DateTime Datetime { get; set; }
	}
}
