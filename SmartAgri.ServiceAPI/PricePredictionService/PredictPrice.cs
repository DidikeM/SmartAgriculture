using Grpc.Net.Client;
using PredictionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SmartAgri.ServiceAPI.PricePredictionService
{
	public class PredictPrice
	{
        public static async Task<string> Predict(string objectName)
		{
			// Specify the gRPC server address
			var channel = GrpcChannel.ForAddress("http://localhost:7334");

			// Create a client for the PricePredictor service
			var client = new PricePredictor.PricePredictorClient(channel);

			// Create a request message
			var request = new PriceRequest
			{
				ObjectName = objectName
			};

			try
			{
				// Make the gRPC call
				var response = await client.predictPricesAsync(request);

				// Print the response
				return $"Predicted Price for {objectName} : {response.Price}";
			}
			catch (Exception ex)
			{
				return $"Error: {ex.Message}";
			}
		}
	}
}
