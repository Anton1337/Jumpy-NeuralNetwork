using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix
{
    private int rows;
    public int Rows {
        get { return rows; }
    }
    private int cols;
    public int Cols
    {
        get { return cols; }
    }
    private List<List<float>> data;
    public List<List<float>> Data {
        get {return data;}
    }
    public Matrix(int rows, int cols){
        this.rows = rows;
        this.cols = cols;

        data = new List<List<float>>();
        for(int i = 0; i < rows; i++){
            data.Add(new List<float>());
            for(int j = 0; j < cols; j++){
                data[i].Add(0f);
            }
        }
    }
    public void Randomize(){
        for(int i = 0; i < rows; i++){
            for(int j = 0; j < cols; j++){
                data[i][j] = Random.Range(-1f, 1f);
            }
        }
    }
    public void Multiply(float n){
        for(int i = 0; i < rows; i++){
            for(int j = 0; j < cols; j++){
                data[i][j] *= n;
            }
        }
    }
    public void Multiply(Matrix m){
        for(int i = 0; i < rows; i++){
            for(int j = 0; j < cols; j++){
                data[i][j] *= m.data[i][j];
            }
        }
    }
    public void Add(float n){
        for(int i = 0; i < rows; i++){
            for(int j = 0; j < cols; j++){
                data[i][j] += n;
            }
        }
    }
    public void Add(Matrix m){
        for(int i = 0; i < rows; i++){
            for(int j = 0; j < cols; j++){
                data[i][j] += m.data[i][j];
            }
        }
    }
    public void Map(System.Func<float, float> func){
        for(int i = 0; i < rows; i++){
            for(int j = 0; j < cols; j++){
                float val = data[i][j];
                data[i][j] = func(val);
            }
        }
    }
    public void PrintMatrix(){
        for(int i = 0; i < rows; i++){
            for(int j = 0; j < cols; j++){
                Debug.Log(data[i][j]);
            }
        }
        Debug.Log("---------END---------");
    }
    public List<float> ToList(){
        List<float> list = new List<float>();
        for(int i = 0; i < rows; i++){
            for(int j = 0; j < cols; j++){
                list.Add(data[i][j]);
            }
        }
        return list;
    }
    
    // -------------------------------------------
    // STATIC METHODS:
    // -------------------------------------------
    public static Matrix Subtract(Matrix a, Matrix b){
        Matrix result = new Matrix(a.Rows, a.Cols);
        for(int i = 0; i < result.Rows; i++){
            for(int j = 0; j < result.Cols; j++){
                result.Data[i][j] = a.Data[i][j] - b.Data[i][j];
            }
        }
        return result;
    }
    public static Matrix Product(Matrix a, Matrix b){
        if(a.cols != b.rows) {return null;}
        
        Matrix result = new Matrix(a.rows, b.cols);
        for(int i = 0; i < result.rows; i++){
            for(int j = 0; j < result.cols; j++){
                float sum = 0;
                for(int k = 0; k < a.cols; k++){
                    sum += a.data[i][k] * b.data[k][j];
                }
                result.data[i][j] = sum;
            }
        }
        return result;
    }

    public static Matrix Transpose(Matrix m){
        Matrix result = new Matrix(m.cols, m.rows); // flipped (transposed)
        for(int i = 0; i < m.rows; i++){
            for(int j = 0; j < m.cols; j++){
                result.data[j][i] = m.data[i][j];
            }
        }
        return result;
    }

    public static Matrix Map(Matrix m, System.Func<float, float> func){
        Matrix result = new Matrix(m.rows, m.cols);
        // Apply a func to every element in matrix
        for(int i = 0; i < m.rows; i++){
            for(int j = 0; j < m.cols; j++){
                float val = m.data[i][j];
                result.data[i][j] = func(val);
            }
        }
        return result;
    }

    public static Matrix FromList(List<float> list){
        Matrix m = new Matrix(list.Count, 1);
        for(int i = 0; i < list.Count; i++){
            m.data[i][0] = list[i];
        }
        return m;
    }
}
