using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static float[] xPos;
    public static float[] yPos;
    public static float[] times;
    public static float[] xVel;
    public static float[] yVel;
    public static float[] xAcc;
    public static float[] yAcc;

    Stopwatch stopwatch2 = new Stopwatch();

    //public Renderer objeRenderer;
    public GameObject objec;

    private bool isMoving = false;
    private bool firstLoop = true;

    public static int curI = 0;

    private float angle;
    private float angle_degrees;
    private Vector3 currentRotation;

    void Start()
    {
        string temp;
        string[] temps = new string[10];
        curI = 0;

        xPos = new float[RunPython.values.Count];
        yPos = new float[RunPython.values.Count];
        xVel = new float[RunPython.values.Count];
        yVel = new float[RunPython.values.Count];
        xAcc = new float[RunPython.values.Count];
        yAcc = new float[RunPython.values.Count];
        times = new float[RunPython.values.Count];

        objec.transform.localRotation = Quaternion.Euler(0, 0, (-1) * Rotation.angle);


        for (int i = 0; i < xPos.Length; i++)
        {
            temp = RunPython.values[i].ToString();
            temps = temp.Split(',');

            times[i] = float.Parse(temps[0]);
            xPos[i] = float.Parse(temps[1]);
            yPos[i] = float.Parse(temps[2]);
            xVel[i] = float.Parse(temps[4]);
            yVel[i] = float.Parse(temps[5]);
            xAcc[i] = float.Parse(temps[7]);
            yAcc[i] = float.Parse(temps[8]);

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

            if (stopwatch2.ElapsedMilliseconds * .001f < times[times.Length - 1])
            {
                angle = Mathf.Atan2(xVel[curI], yVel[curI]);
                angle_degrees = angle * 180 / Mathf.PI;

                objec.transform.position = new Vector3(-xPos[curI], yPos[curI], 0);
                objec.transform.rotation = Quaternion.Euler(0, 0, angle_degrees);

                curI = calcI(stopwatch2.ElapsedMilliseconds * .001f);

            }
            else
            {
                isMoving = false;
                firstLoop = true;
                stopwatch2.Reset();
                
            }
        }
    }

    public void move()
    {
        isMoving = true;
        curI = 0;

    }

    public int calcI(float time)
    {
        for (int i = curI; i < xPos.Length; i++)
        {
            if (times[i] > time)
            {
                return i;
            }
        }

        return xPos.Length;
    }
}