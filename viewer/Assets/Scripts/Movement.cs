using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static float[] xPos = new float[ReadCSV.values.Count];
    public static float[] yPos = new float[ReadCSV.values.Count];
    public static float[] times = new float[ReadCSV.values.Count];

    Stopwatch stopwatch2 = new Stopwatch();

    //public Renderer objeRenderer;
    public GameObject objec;

    private bool isMoving = false;
    private bool firstLoop = true;

    int curI = 0;

    void Start()
    {
        string temp;
        string[] temps = new string[7];

        //objeRenderer = objec.GetComponent<Transform>();

        for (int i = 1; i < xPos.Length ; i++)
        {
            temp = ReadCSV.values[i].ToString();
            temps = temp.Split(',');

            times[i] = float.Parse(temps[0]);
            xPos[i] = float.Parse(temps[1]);
            yPos[i] = float.Parse(temps[2]);

            //print(xPos[i] + " " + yPos[i] + " " + times[i] + "\n");
        }
    }

    void Update()
    {
        if (isMoving)
        {
            if (firstLoop)
            {
                firstLoop = false;
                stopwatch2.Start();
            }

            if (stopwatch2.ElapsedMilliseconds * .001f < times[times.Length-1])
            {
                objec.transform.position = new Vector3(xPos[curI], yPos[curI], -15);
                
                curI = calcI(stopwatch2.ElapsedMilliseconds * .001f);

                //objec.transform.position = new Vector3(14, 0, -15);
            } else
            {
                isMoving = false;
                firstLoop = true;
                stopwatch2.Reset();
            }
        }
    }

    public void move ()
    {
        isMoving = true;
    }

    public int calcI(float time)
    {
        for (int i = 0; i < xPos.Length; i++ )
        {
            if (times[i] > time)
            {
                return i;
            }
        }

        return xPos.Length;
    }
}
