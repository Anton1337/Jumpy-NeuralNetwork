using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perceptron
{
    private List<float> weights = new List<float>();
    private float learningRate = 0.1f;

    public Perceptron(int numOfWeights)
    {
        for(int i = 0; i < numOfWeights; i++)
        {
            // Init weights randomly.
            float weight = Random.Range(-1f, 1f);
            weights.Add(weight);
        }
    }

    public int Guess(List<float> inputs)
    {
        float sum = 0;
        for(int i = 0; i < weights.Count; i++)
        {
            sum += inputs[i] * weights[i];
        }
        // Activation function.
        int output = (int) Mathf.Sign(sum);
        return output;
    }

    public void Train(List<float> inputs, int target)
    {
        int guess = Guess(inputs);
        int error = target - guess;

        // Tune all the weights
        for(int i = 0; i < weights.Count; i++)
        {
            weights[0] += error * inputs[i] * learningRate;
        }
    }
}
