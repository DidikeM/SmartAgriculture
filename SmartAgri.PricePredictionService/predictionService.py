import grpc
import predictionService_pb2
import predictionService_pb2_grpc

import os
import sys
from concurrent import futures

from LSTM_Prediction import predict_prices

class predictionServicer(predictionService_pb2_grpc.PricePredictor):
    def predictPrices(self, request, context):
        prediction = predict_prices(request.objectName)
        return predictionService_pb2.PriceResponse(
            price = prediction
        )

def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    predictionService_pb2_grpc.add_PricePredictorServicer_to_server(
        predictionServicer(), server
    )
    server.add_insecure_port("localhost:7334")
    print("Server Started http://localhost:7334")
    server.start()
    server.wait_for_termination()

if __name__ == "__main__":
    serve()