using System;

namespace XamarinPowerShop.Entities
{
	/// <summary>
	/// Order.
	/// </summary>
	public class Order
	{
		public string ProductReference { get; set; }
		public string ProductName { get; set; }
		public bool IsMen { get; set; }
		public string Size { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime TimeSlots { get; set; }
		public int HourSlots { get; set; }
	}
}

