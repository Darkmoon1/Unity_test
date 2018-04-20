using UnityEngine;
using System.Collections;

public class snakeHeadMove : MonoBehaviour {
    public int direction = 0;
    private GameObject GM;
    private gameManager gm;
    public bool readyToRot = true;
    //0up 1right 2down 3left
	// Use this for initialization
	void Start () {
        GM = GameObject.Find("GameManager");
        gm = GM.GetComponent<gameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(direction);
        if (readyToRot)
        {
            if (Input.GetKeyDown(KeyCode.A) && direction != 1)
            {
                gm.myTransform.Rotate(0, 0, (3 - direction) * -90);
                direction = 3;
                readyToRot = false;
            }
            if (Input.GetKeyDown(KeyCode.D) && direction != 3)
            {
                gm.myTransform.Rotate(0, 0, (1 - direction) * -90);
                direction = 1;
                readyToRot = false;
            }
            if (Input.GetKeyDown(KeyCode.W) && direction != 2)
            {
                gm.myTransform.Rotate(0, 0, (0 - direction) * -90);
                direction = 0;
                readyToRot = false;
            }
            if (Input.GetKeyDown(KeyCode.S) && direction != 0)
            {
                gm.myTransform.Rotate(0, 0, (2 - direction) * -90);
                direction = 2;
                readyToRot = false;
            }
        }

    }
}
