using Grpc.Net.Client;
using PredictionService;
using SmartAgri.Entities.Enums;
using SmartAgri.ServiceAPI.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SmartAgri.ServiceAPI.Concrete.PricePredictionService
{
    public class PredictPrice : IPredictPrice
    {
        public async Task<decimal> Predict(ProductEnum product)
        {
            // Specify the gRPC server address
            var channel = GrpcChannel.ForAddress("http://localhost:7334");

            // Create a client for the PricePredictor service
            var client = new PricePredictor.PricePredictorClient(channel);

            // Create a request message
            var request = new PriceRequest
            {
                ObjectName = product.ToString()
            };

            try
            {
                // Make the gRPC call
                var response = await client.predictPricesAsync(request);

                // Print the response
                return Convert.ToDecimal(response.Price);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
