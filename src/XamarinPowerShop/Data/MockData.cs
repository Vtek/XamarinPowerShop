using System.Collections.Generic;

namespace XamarinPowerShop
{
	/// <summary>
	/// Mock data.
	/// </summary>
	public static class MockData
	{
		/// <summary>
		/// Gets the csharp t-shirt data.
		/// </summary>
		/// <returns>The csharp.</returns>
		public static List<TShirt> GetCsharp()
		{
			return new List<TShirt> 
			{ 
				new TShirt
				{
					Name = "C# River T-Shirt",
					Reference = "C-R",
					ImageFile = "csharpriver.png"
				},
				new TShirt
				{
					Name = "C# Emerald T-Shirt",
					Reference = "C-E",
					ImageFile = "csharpemerald.png"
				},
				new TShirt
				{
					Name = "C# Asphalt T-Shirt",
					Reference = "C-A",
					ImageFile = "csharpasphalt.png"
				}
			};
		}

		/// <summary>
		/// Gets the fsharp t-shirt data.
		/// </summary>
		/// <returns>The fsharp.</returns>
		public static List<TShirt> GetFsharp()
		{
			return new List<TShirt> 
			{ 
				new TShirt
				{
					Name = "F# River T-Shirt",
					Reference = "F-R",
					ImageFile = "fsharpriver.png"
				},
				new TShirt
				{
					Name = "F# Emerald T-Shirt",
					Reference = "F-E",
					ImageFile = "fsharpemerald.png"
				},
				new TShirt
				{
					Name = "F# Asphalt T-Shirt",
					Reference = "F-A",
					ImageFile = "fsharpasphalt.png"
				}
			};
		}
	}
}

