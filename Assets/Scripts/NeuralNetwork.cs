using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuralNetwork
{
    private int inputNodes;
    private int hiddenNodes;
    private int outputNodes;
    private Matrix weightsIH; // input-hidden
    private Matrix weightsHO; // hidden-output
    private Matrix biasH; // hidden
    private Matrix biasO; // output

    public NeuralNetwork(int iN, int hN, int oN){
        inputNodes = iN;
        hiddenNodes = hN;
        outputNodes = oN;

        weightsIH = new Matrix(hiddenNodes, inputNodes);
        weightsIH.Randomize();
        weightsHO = new Matrix(outputNodes, hiddenNodes);
        weightsHO.Randomize();
        biasH = new Matrix(hiddenNodes, 1);
        biasH.Randomize();
        biasO = new Matrix(outputNodes, 1);
        biasH.Randomize();
    }
    public List<float> FeedForward(List<float> inputList){
        // Generatung hidden layer output.
        Matrix inputs = Matrix.FromList(inputList);
        Matrix hiddenOutputs = Matrix.Product(weightsIH, inputs);
        hiddenOutputs.Add(biasH);

        // Activation function
        hiddenOutputs.Map(Sigmoid);

        // Generating output layer output.
        Matrix output = Matrix.Product(weightsHO, hiddenOutputs);
        output.Add(biasO);
        output.Map(Sigmoid);
        return output.ToList();
    }
    public void Train(List<float> inputList, List<float> targetList)
    {
        List<float> outputList = FeedForward(inputList);
        Matrix outputs = Matrix.FromList(outputList); // NOT WORKING???
        Matrix targets = Matrix.FromList(targetList); // NOT WORKING????


        // Calculate error
        Matrix error = Matrix.Subtract(targets, outputs);
        outputs.PrintMatrix();
        targets.PrintMatrix();
        error.PrintMatrix();

    }

    //----------------------------------
    // ACTIVATION FUNCTIONS
    //----------------------------------
    private float Sigmoid(float x){
        return 1 / (1 + Mathf.Exp(-x));
    }
}
