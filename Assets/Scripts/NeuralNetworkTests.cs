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
            List<float> inputList = new List<float>() {1f, 0f};
            List<float> targetList = new List<float>() {1f};
            NeuralNetwork nn = new NeuralNetwork(2, 2, 1);

            nn.Train(inputList, targetList);
        }
    }


}
