using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptronTests : MonoBehaviour
{

    class Point
    {
        public int x;
        public int y;
        public int bias;
        public int label;

        public Point()
        {
            bias = 1;
            x = Random.Range(0, 20);
            y = Random.Range(0, 20);
            label = (x >= y) ? 1 : -1;
        }
    }
    void Start()
    {
        {
            List<float> inputs = new List<float>() { -1f, 0.5f };
            Perceptron p = new Perceptron(inputs.Count + 1); // + bias
            GuessIt(p);
            GuessIt(p);
            GuessIt(p);
            GuessIt(p);
            TrainIt(p);
            for(int i = 0; i < 10; i++)
            {
                GuessIt(p);
            }
        }
    }

    void TrainIt(Perceptron p)
    {
        List<Point> points = new List<Point>();
        const int numOfPoints = 100;
        for(int i = 0; i < numOfPoints; i++)
        {
            points.Add(new Point());
        }

        foreach(Point pt in points)
        {
            p.Train(new List<float>() { pt.x, pt.y, pt.bias }, pt.label);
        }
    }

    void GuessIt(Perceptron p)
    {
        List<Point> points = new List<Point>();
        const int numOfPoints = 100;
        for (int i = 0; i < numOfPoints; i++)
        {
            points.Add(new Point());
        }

        int correctAnswers = 0;
        foreach (Point pt in points)
        {
            int guess = p.Guess(new List<float>() { pt.x, pt.y, pt.bias });
            if (guess == pt.label) correctAnswers++;
        }

        Debug.Log("PERCENTAGE CORRECT: " + ((float)correctAnswers) / ((float)numOfPoints)
            + " C ANS " + correctAnswers);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
