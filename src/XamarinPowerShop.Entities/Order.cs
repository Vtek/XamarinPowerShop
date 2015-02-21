using System;

namespace XamarinPowerShop.Entities
{
	/// <summary>
	/// Order.
	/// </summary>
	public class Order
	{
		/// <summary>
		/// Gets or sets the product reference.
		/// </summary>
		/// <value>The product reference.</value>
		public string ProductReference { get; set; }

		/// <summary>
		/// Gets or sets the name of the product.
		/// </summary>
		/// <value>The name of the product.</value>
		public string ProductName { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the order is for a men.
		/// </summary>
		/// <value><c>true</c> if this instance is men; otherwise, <c>false</c>.</value>
		public bool IsMen { get; set; }

		/// <summary>
		/// Gets or sets the size.
		/// </summary>
		/// <value>The size.</value>
		public string Size { get; set; }

		/// <summary>
		/// Gets or sets the order date.
		/// </summary>
		/// <value>The order date.</value>
		public DateTime OrderDate { get; set; }

		/// <summary>
		/// Gets or sets the time slots.
		/// </summary>
		/// <value>The time slots.</value>
		public DateTime TimeSlots { get; set; }

		/// <summary>
		/// Gets or sets the hour slots.
		/// </summary>
		/// <value>The hour slots.</value>
		public int HourSlots { get; set; }
	}
}

