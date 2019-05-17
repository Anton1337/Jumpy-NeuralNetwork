using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NNData
{
    public List<float> inputs;
    public List<float> targets;

    public NNData(List<float> inputs, List<float> targets)
    {
        this.inputs = inputs;
        this.targets = targets;
    }
}
