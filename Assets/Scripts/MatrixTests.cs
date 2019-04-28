using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixTests : MonoBehaviour
{
    void Start()
    {
        /* {
            // ADD, MULTIPLY, AND RANDOMIZE TESTS.
            Matrix matrix = new Matrix(3, 3);

            Debug.Log("DEFAULT MATRIX:");
            matrix.PrintMatrix();
            Debug.Log("-----------------");

            Debug.Log("ADD:");
            matrix.Add(2);
            matrix.PrintMatrix();
            Debug.Log("-----------------");

            Debug.Log("MULTIPLY:");
            matrix.Multiply(-2);
            matrix.PrintMatrix();
            Debug.Log("-----------------");

            Debug.Log("RANDOMIZE:");
            matrix.Randomize();
            matrix.PrintMatrix();
            Debug.Log("-----------------");

            Matrix matrix2 = new Matrix(3, 3);
            matrix2.Randomize();
            Debug.Log("DEFAULT MATRIX2:");
            matrix2.PrintMatrix();
            Debug.Log("-----------------");

            Debug.Log("MATRIXES ADDED TOGETHER:");
            matrix.Add(matrix2);
            matrix.PrintMatrix();
            Debug.Log("-----------------");
        } */

        /* {
            // PRODUCT
            Debug.Log("FIRST MATRIX:");
            Matrix matrix = new Matrix(2, 3);
            matrix.Randomize();
            matrix.PrintMatrix();
            Debug.Log("----------------");

            Debug.Log("SECOND MATRIX:");
            Matrix matrix2 = new Matrix(3, 2);
            matrix2.Randomize();
            matrix2.PrintMatrix();
            Debug.Log("----------------");

            Debug.Log("PRODUCT MATRIX:");
            Matrix productMatrix = Matrix.Product(matrix, matrix2);
            productMatrix.PrintMatrix();
            Debug.Log("----------------");
        } */

        /* {
            // MAP
            Matrix matrix = new Matrix(3,3);
            matrix.Add(2);
            matrix.Map(doubleIt);
            matrix.PrintMatrix();
        } */
        
    }

    // To test Map().
    float doubleIt(float val){
        return val * 2;
    }

}
