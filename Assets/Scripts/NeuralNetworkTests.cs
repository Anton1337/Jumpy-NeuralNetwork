using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuralNetworkTests : MonoBehaviour
{
    void Start()
    {
       /*  {
            // FEEDFORWARD
            List<float> inputList = new List<float>() {1f, 0f};
            NeuralNetwork nn = new NeuralNetwork(2, 2, 1);

            List<float> outputList = nn.FeedForward(inputList);
            Debug.Log("OUTPUT LIST: " + outputList[0]);

        } */

        {
            // SOLVING XOR WITH NEURAL NETWORK
            List<XORTrainingData> tData = new List<XORTrainingData>(){
                new XORTrainingData(new List<float>(){0f, 0f}, new List<float>(){0f}),
                new XORTrainingData(new List<float>(){1f, 0f}, new List<float>(){1f}),
                new XORTrainingData(new List<float>(){0f, 1f}, new List<float>(){1f}),
                new XORTrainingData(new List<float>(){1f, 1f}, new List<float>(){0f}) 
            };
            NeuralNetwork nn = new NeuralNetwork(2, 8, 1);

            //BEFORE TRAINED.
            List<float> guess = nn.FeedForward(new List<float>() { 0f, 0f });
            Debug.Log("GUESS FOR 0, 0: " + guess[0]);
            List<float> guess2 = nn.FeedForward(new List<float>() { 1f, 0f });
            Debug.Log("GUESS FOR 1, 0: " + guess2[0]);
            List<float> guess3 = nn.FeedForward(new List<float>() { 0f, 1f });
            Debug.Log("GUESS FOR 0, 1: " + guess3[0]);
            List<float> guess4 = nn.FeedForward(new List<float>() { 1f, 1f });
            Debug.Log("GUESS FOR 1, 1: " + guess4[0]);

            for (int i = 0; i < 100; i++){
                XORTrainingData data = tData[Random.Range(0, 4)];
                    nn.Train(data.inputs, data.targets);
            }

            List<float> guess5 = nn.FeedForward(new List<float>(){0f, 0f});
            Debug.Log("GUESS FOR 0, 0: " + guess5[0]);
            List<float> guess6 = nn.FeedForward(new List<float>(){1f, 0f});
            Debug.Log("GUESS FOR 1, 0: " + guess6[0]);
            List<float> guess7 = nn.FeedForward(new List<float>(){0f, 1f});
            Debug.Log("GUESS FOR 0, 1: " + guess7[0]);
            List<float> guess8 = nn.FeedForward(new List<float>(){1f, 1f});
            Debug.Log("GUESS FOR 1, 1: " + guess8[0]);
        }

        {
            // COLOR PREDICTOR
            // targets: (RED, GREEN, BLUE, YELLOW, PURPLE)
            List<NNData> trainingData = new List<NNData>()
            {
                new NNData(new List<float>(){66f, 244f, 113f}, new List<float>(){0f, 1f, 0f, 0f, 0f}),
                new NNData(new List<float>(){0f ,250f, 154f}, new List<float>(){0f, 1f, 0f, 0f, 0f}),
                new NNData(new List<float>(){152f, 251f, 152f}, new List<float>(){0f, 1f, 0f, 0f, 0f}),
                new NNData(new List<float>(){50f, 205f, 50f}, new List<float>(){0f, 1f, 0f, 0f, 0f}),
                new NNData(new List<float>(){255f, 69f, 0f}, new List<float>(){1f, 0f, 0f, 0f, 0f}),
                new NNData(new List<float>(){139f, 0f, 0f}, new List<float>(){1f, 0f, 0f, 0f, 0f}),
                new NNData(new List<float>(){255f, 0f, 0f}, new List<float>(){1f, 0f, 0f, 0f, 0f}),
                new NNData(new List<float>(){178f, 34f, 34f}, new List<float>(){1f, 0f, 0f, 0f, 0f}),
                new NNData(new List<float>(){0f, 0f, 128f}, new List<float>(){0f, 0f, 1f, 0f, 0f}),
                new NNData(new List<float>(){0f, 0f, 255f}, new List<float>(){0f, 0f, 1f, 0f, 0f}),
                new NNData(new List<float>(){135f, 206f, 250f}, new List<float>(){0f, 0f, 1f, 0f, 0f}),
                new NNData(new List<float>(){0f, 191f, 255f}, new List<float>(){0f, 0f, 1f, 0f, 0f}),
                new NNData(new List<float>(){255f, 215f, 0f}, new List<float>(){0f, 0f, 0f, 1f, 0f}),
                new NNData(new List<float>(){255f, 255f, 0f}, new List<float>(){0f, 0f, 0f, 1f, 0f}),
                new NNData(new List<float>(){207f, 200f, 44f}, new List<float>(){0f, 0f, 0f, 1f, 0f}),
                new NNData(new List<float>(){164f, 179f, 22f}, new List<float>(){0f, 0f, 0f, 1f, 0f}),
                new NNData(new List<float>(){128f, 0f, 128f}, new List<float>(){0f, 0f, 0f, 0f, 1f}),
                new NNData(new List<float>(){153f, 50f, 204f}, new List<float>(){0f, 0f, 0f, 0f, 1f}),
                new NNData(new List<float>(){148f, 0f, 211f}, new List<float>(){0f, 0f, 0f, 0f, 1f}),
                new NNData(new List<float>(){147f, 112f, 219f}, new List<float>(){0f, 0f, 0f, 0f, 1f}),
            };
            List<List<float>> testingData = new List<List<float>>()
            {
                new List<float>(){25f, 226f, 75f},
                new List<float>(){17f, 151f, 50f}, // GREEN
                new List<float>(){229f, 26f, 26f},
                new List<float>(){188f, 39f, 39f}, // RED
                new List<float>(){32f, 185f, 204f},
                new List<float>(){32f, 101f, 204f}, // BLUE
                new List<float>(){251f, 255f, 0f},
                new List<float>(){178f, 180f, 51f}, // YELLOW
                new List<float>(){156f, 0f, 255f},
                new List<float>(){107f, 28f, 146f} // PURPLE
            };
            NeuralNetwork nn = new NeuralNetwork(3, 8, 5);

            for (int i = 0; i < 1000; i++)
            {
                NNData data = trainingData[Random.Range(0, trainingData.Count)];
                nn.Train(data.inputs, data.targets);
            }

            foreach(List<float> list in testingData)
            {
                List<float> guess = nn.FeedForward(list);
                
            }


        }
    }
}
