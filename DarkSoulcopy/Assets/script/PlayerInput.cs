using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    [Header("Key Settings")]
    public string keyUP = "w";
    public string keyDown = "s";
    public string keyLeft = "a";
    public string keyRight = "d";
    // Use this for initialization
    public string keyA = "left shift";    
    public string keyB = "space";
    public string keyC;
    public string keyD;

    public string keyJringht;
    public string keyJleft;
    public string keyJup;
    public string keyJdown;


    [Header("OutPut Signal")]
    public float Dup;
    public float Dright;
    public float Dmag;
    public Vector3 Dvec;
    public float Jup;
    public float Jright;

    //1.pressing signal 2.trigger once signal 3.double trigger
    public bool run = false;
    public bool jump;
    private bool lastJump;

    [Header("Others")]

    public bool inputEnabled = true;

    private float targetDup;
    private float targetDright;

    private float velocityDup;
    private float velocityDright;
    void Start () {
	
	}
	
	// Update is called once per frame


	void Update () {

        Jup = (Input.GetKey(keyJup) ? 1.0f : 0) - (Input.GetKey(keyJdown) ? 1.0f : 0);
        Jright = (Input.GetKey(keyJleft) ? 1.0f : 0) - (Input.GetKey(keyJringht) ? 1.0f : 0);

        targetDright = (Input.GetKey(keyRight) ? 1.0f : 0) - (Input.GetKey(keyLeft) ? 1.0f : 0);
        targetDup = (Input.GetKey(keyUP) ? 1.0f : 0) - (Input.GetKey(keyDown) ? 1.0f : 0);

        if (!inputEnabled)
        {
            targetDup = 0;
            targetDright = 0;
        }
 
        Dup = Mathf.SmoothDamp(Dup, targetDup, ref velocityDup, 0.1f);
        Dright = Mathf.SmoothDamp(Dright, targetDright, ref velocityDright, 0.1f);

        Vector2 tempDAxis = SquareToCiracle(Dright, Dup);
        float Dup2 = tempDAxis.y;
        float Dright2 = tempDAxis.x;

        Dmag = Mathf.Sqrt((Dup2 * Dup2) + (Dright2 * Dright2));
        Dvec = Dright2 * transform.right + Dup2 * transform.forward;

        run = Input.GetKey(keyA);

        jump = Input.GetKeyDown(keyB);
    }

    private Vector2 SquareToCiracle(float Dright,float Dup)
    {
        Vector2 outPut = Vector2.zero;

        outPut.x = Dright * Mathf.Sqrt(1 - (Dup * Dup) / 2.0f);
        outPut.y = Dup * Mathf.Sqrt(1 - (Dright * Dright) / 2.0f);

        return outPut;
    }
}
