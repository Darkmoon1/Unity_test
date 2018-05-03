using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
    public string keyUP = "w";
    public string keyDown = "s";
    public string keyLeft = "a";
    public string keyRight = "d";
    // Use this for initialization

    public float Dup;
    public float Dright;
    public float Dmag;
    public Vector3 Dvec;

    public bool inputEnabled = true;

    private float targetDup;
    private float targetDright;

    private float velocityDup;
    private float velocityDright;
    void Start () {
	
	}
	
	// Update is called once per frame


	void Update () {
        targetDright = (Input.GetKey(keyLeft) ? 1.0f : 0) - (Input.GetKey(keyRight) ? 1.0f : 0);
        targetDup = (Input.GetKey(keyUP) ? 1.0f : 0) - (Input.GetKey(keyDown) ? 1.0f : 0);

        if (!inputEnabled)
        {
            targetDup = 0;
            targetDright = 0;
        }
 
        Dup = Mathf.SmoothDamp(Dup, targetDup, ref velocityDup, 0.1f);
        Dright = Mathf.SmoothDamp(Dright, targetDright, ref velocityDright, 0.1f);
        Dmag = Mathf.Sqrt((Dup * Dup) + (Dright * Dright));
        Dvec = Dright * transform.right + Dup * transform.forward;


    }
}
