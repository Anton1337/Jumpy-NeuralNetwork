using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationFunctions
{
    public float Sigmoid(float x){
        int exp = (int) x; 
        return 1 / (1 + Mathf.Exp(-exp));
    }
}
