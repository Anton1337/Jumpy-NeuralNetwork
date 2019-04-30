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
            
            for(int i = 0; i < 10000; i++){
                XORTrainingData data = tData[Random.Range(0, 4)];
                    nn.Train(data.inputs, data.targets);
            }

            List<float> guess = nn.FeedForward(new List<float>(){0f, 0f});
            Debug.Log("GUESS FOR 0, 0: " + guess[0]);
            List<float> guess2 = nn.FeedForward(new List<float>(){1f, 0f});
            Debug.Log("GUESS FOR 1, 0: " + guess2[0]);
            List<float> guess3 = nn.FeedForward(new List<float>(){0f, 1f});
            Debug.Log("GUESS FOR 0, 1: " + guess3[0]);
            List<float> guess4 = nn.FeedForward(new List<float>(){1f, 1f});
            Debug.Log("GUESS FOR 1, 1: " + guess4[0]);
        }
    }


}
