using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XORTrainingData
{
    public List<float> inputs;
    public List<float> targets;

    public XORTrainingData(List<float> inputs, List<float> targets){
        this.inputs = inputs;
        this.targets = targets;
    }
}
