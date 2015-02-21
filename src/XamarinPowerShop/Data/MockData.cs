using System;
using System.Collections.Generic;

namespace XamarinPowerShop
{
	public static class MockData
	{
		public static List<TShirt> GetCsharp()
		{
			return new List<TShirt> 
			{ 
				new TShirt
				{
					Name = "C# River T-Shirt",
					Reference = "C-R",
					ImageFile = "csharp-river.png"
				},
				new TShirt
				{
					Name = "C# Emerald T-Shirt",
					Reference = "C-E",
					ImageFile = "csharp-emerald.png"
				},
				new TShirt
				{
					Name = "C# Asphalt T-Shirt",
					Reference = "C-A",
					ImageFile = "csharp-asphalt.png"
				}
			};
		}

		public static List<TShirt> GetFsharp()
		{
			return new List<TShirt> 
			{ 
				new TShirt
				{
					Name = "F# River T-Shirt",
					Reference = "F-R",
					ImageFile = "fsharp-river.png"
				},
				new TShirt
				{
					Name = "F# Emerald T-Shirt",
					Reference = "F-E",
					ImageFile = "fsharp-emerald.png"
				},
				new TShirt
				{
					Name = "F# Asphalt T-Shirt",
					Reference = "F-A",
					ImageFile = "fsharp-asphalt.png"
				}
			};
		}
	}
}

