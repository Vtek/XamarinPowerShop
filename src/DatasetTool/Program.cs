using System;
using PowerBI.Api.Client;
using XamarinPowerShop.Entities;

namespace DatasetTool
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			if(args.Length != 0)
			{
				if(args[0].Equals("delete"))
				{
					var isDelete = PowerBIClient.Do<bool>(api => api.Delete<Order>(api.GetDatasetId("XamarinPowerShop")));

					if(isDelete)
					{
						Console.WriteLine("Xamarin Power Shop, order rows deleted !");
					}
					else
					{
						Console.WriteLine("Xamarin Power Shop, failed to delete all rows !");
					}
				}
			}
			else
			{
				var isCreated = PowerBIClient.Do<bool>(api => api.CreateDataset("XamarinPowerShop", typeof(Order)));

				if(isCreated)
				{
					Console.WriteLine("Xamarin Power Shop, dataset created !");
				}
				else
				{
					Console.WriteLine("Xamarin Power Shop, failed to create dataset !");
				}
			}

			Console.ReadKey();
		}
	}
}
