using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {
    private float beginTime;
    private float limitTime = 0;
    private bool isCreated = false;
    public bool timeOut = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(isCreated);
        //Debug.Log(Time.time);
        //Debug.Log(beginTime);
        //Debug.Log(limitTime);
        //Debug.Log(Time.time - beginTime);
        if (isCreated)
        {
            if (Time.time - beginTime >= limitTime)
                timeOut = true;
        }
	}

    public void createtimer(float x)
    {
        limitTime = x;
        beginTime = Time.time;
        isCreated = true;
        Debug.Log(isCreated);
        //Debug.Log(x);
    }
    public void resettimer()
    {
        beginTime = Time.time;
        timeOut = false;
    }

    public void stoptimer()
    {
        isCreated = false;
        timeOut = false;
        limitTime = 0;
    }
}
