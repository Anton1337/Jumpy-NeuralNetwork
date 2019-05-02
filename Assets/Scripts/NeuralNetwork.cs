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
    private float learningRate = 0.1f;

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
        // Generating hidden layer output.
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
        // Generating hidden layer output.
        Matrix inputs = Matrix.FromList(inputList);
        Matrix hiddenOutputs = Matrix.Product(weightsIH, inputs);
        hiddenOutputs.Add(biasH);

        // Activation function
        hiddenOutputs.Map(Sigmoid);

        // Generating output layer output.
        Matrix outputs = Matrix.Product(weightsHO, hiddenOutputs);
        outputs.Add(biasO);
        outputs.Map(Sigmoid);

        // Convert targets into matrix
        Matrix targets = Matrix.FromList(targetList);

        // Calculate errors
        // ERROR = TARGETS - OUTPUTS
        Matrix outputErrors = Matrix.Subtract(targets, outputs);
        
        // Calculate gradient
        Matrix gradients = Matrix.Map(outputs, DSigmoid);
        gradients.Multiply(outputErrors);
        gradients.Multiply(learningRate);

        // Calculate deltas
        Matrix hiddenTransposed = Matrix.Transpose(hiddenOutputs);
        Matrix weightHODeltas = Matrix.Product(gradients, hiddenTransposed);

        // Adjust weights (and bias) by deltas!!!
        weightsHO.Add(weightHODeltas);
        biasO.Add(gradients); // gradients == deltaBias

        // Calculate hidden layer errors
        Matrix weightsHOTransposed = Matrix.Transpose(this.weightsHO);
        Matrix hiddenErrors = Matrix.Product(weightsHOTransposed, outputErrors);

        // Calculate hidden layer gradient
        Matrix hiddenGradients = Matrix.Map(hiddenOutputs, DSigmoid);
        hiddenGradients.Multiply(hiddenErrors);
        hiddenGradients.Multiply(learningRate);

        // Calculate hidden deltas
        Matrix inputsTransposed = Matrix.Transpose(inputs);
        Matrix weightIHDeltas = Matrix.Product(hiddenGradients, inputsTransposed);

        // Adjust weights!!!
        weightsIH.Add(weightIHDeltas);
        biasH.Add(hiddenGradients);
    }

    //----------------------------------
    // ACTIVATION FUNCTIONS
    //----------------------------------
    private float Sigmoid(float x){
        return 1 / (1 + Mathf.Exp(-x));
    }

    // Derivitive of sigmoid
    private float DSigmoid(float y){
        //return Sigmoid(x) * (1 - Sigmoid(x));
        return y * (1 - y); // Used after already being derivitived
    }
}
