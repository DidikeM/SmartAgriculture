from tensorflow.keras.models import load_model
import pandas as pd
import joblib
import numpy as np

n_steps = 10

def create_sequences(data, n_steps):
    X, y = [], []
    for i in range(len(data)):
        end_ix = i + n_steps
        if end_ix > len(data) - 1:
            break
        seq_x, seq_y = data[i:end_ix], data[end_ix]
        X.append(seq_x)
        y.append(seq_y)
    return np.array(X), np.array(y)

def predict_prices(item):
    df_pred = pd.read_csv("./Dataset/" + item + ".csv")
    df_pred['DATE'] = pd.to_datetime(df_pred['DATE'])
    df_pred.set_index('DATE', inplace=True)
    loaded_model = load_model("Dataset/" + item + "/model.keras")

    testScaler = joblib.load("Dataset/" + item + '/scaler.pkl')

    data_train = df_pred['PRICE'].values.reshape(-1, 1)

    testScaler.fit(data_train)

    data_pred = testScaler.transform(df_pred['PRICE'].values.reshape(-1, 1))

    X_pred, y_pred = create_sequences(data_pred, n_steps)

    X_pred = X_pred.reshape((X_pred.shape[0], X_pred.shape[1], 1))

    y_pred_new = loaded_model.predict(X_pred)

    y_pred_new = testScaler.inverse_transform(y_pred_new)


    return y_pred_new[-1][0]
