using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {
    public float speed ;
    public float limitTime = 0.5f;
    public GameObject snake;
    public GameObject Timer;
    public GameObject body;
    private GameObject []snakeBodys = new GameObject[999];
    private GameObject mysnake;
    private snakeHeadMove snakeheadmove;
    private timer snakeTimer;
    private eat snakeEat;
    private float boxSize;
    public Transform myTransform;
    private int lastBody = 0;
    //int direction;
    //0up 1right 2down 3left
    // Use this for initialization
    void Start () {
        //Debug.Log(body.GetComponent<BoxCollider2D>().size.x);
        speed = body.GetComponent<BoxCollider2D>().size.y*0.3f;
        boxSize = speed;
        mysnake = Instantiate(snake);
        myTransform = mysnake.transform;
        snakeheadmove = mysnake.GetComponentInChildren<snakeHeadMove>();
        snakeEat = mysnake.GetComponentInChildren<eat>();
        snakeBodys[lastBody] = Instantiate(body);
        snakeBodys[lastBody].transform.Translate(transform.position - new Vector3(0, boxSize, 0));
        snakeBodys[lastBody].GetComponent<Body>().theFormerBody = mysnake;
        snakeBodys[lastBody].GetComponent<Body>().direction = snakeheadmove.direction;
        lastBody++;
        snakeBodys[lastBody] = Instantiate(body);
        snakeBodys[lastBody].transform.Translate(transform.position - new Vector3(0, boxSize*2, 0));
        snakeBodys[lastBody].GetComponent<Body>().theFormerBody = snakeBodys[lastBody-1];
        snakeBodys[lastBody].GetComponent<Body>().direction = snakeBodys[lastBody - 1].GetComponent<Body>().direction;
        snakeTimer = Instantiate(Timer).GetComponent<timer>();
        snakeTimer.createtimer(limitTime);
	}
	
	// Update is called once per frame
	void Update () {
        //direction = snakeheadmove.direction;
        if (snakeTimer.timeOut)
        {
            //Debug.Log(snakeTimer.timeOut);
            //    switch (direction)
            //    {
            //        case 0: myTransform.Translate(transform.up * speed);
            //            break;
            //        case 1: myTransform.Translate(transform.right * speed);
            //            break;
            //        case 2: myTransform.Translate(transform.up * -speed);
            //            break;
            //        case 3: myTransform.Translate(transform.right * -speed);
            //            break;
            //    }
            //    snakeTimer.resettimer();
            for (int i = lastBody; i >= 1; i--)
            {
                Debug.Log(i);
                Body tBody = snakeBodys[i].GetComponent<Body>();
                tBody.direction = tBody.theFormerBody.GetComponent<Body>().direction;
                snakeBodys[i].transform.position = tBody.theFormerBody.transform.position;
            }
            snakeBodys[0].GetComponent<Body>().direction = snakeheadmove.direction;
            snakeBodys[0].transform.position = snakeBodys[0].GetComponent<Body>().theFormerBody.transform.position;

            myTransform.Translate(transform.up * speed);
            snakeheadmove.readyToRot = true;
            snakeTimer.resettimer();
        }
        if (snakeEat.situation != 0)
        {
            switch (snakeEat.situation)
            {
                case 1:
                    lastBody++;
                    snakeBodys[lastBody] = Instantiate(body);
                    Body newBody = snakeBodys[lastBody].GetComponent<Body>();
                    newBody.theFormerBody = snakeBodys[lastBody - 1];
                    switch (newBody.theFormerBody.GetComponent<Body>().direction)
                    {
                        case 0:
                            snakeBodys[lastBody].transform.Translate(snakeBodys[lastBody-1].transform.position - new Vector3(0, boxSize, 0));
                            break;
                        case 1:
                            snakeBodys[lastBody].transform.Translate(snakeBodys[lastBody - 1].transform.position - new Vector3(boxSize,0 , 0));
                            break;
                        case 2:
                            snakeBodys[lastBody].transform.Translate(snakeBodys[lastBody - 1].transform.position - new Vector3(0, -boxSize, 0));
                            break;
                        case 3:
                            snakeBodys[lastBody].transform.Translate(snakeBodys[lastBody - 1].transform.position - new Vector3(-boxSize, 0, 0));
                            break;

                    }
                    newBody.direction = newBody.theFormerBody.GetComponent<Body>().direction;
                    snakeEat.situation = 0;
                    break;
                case 2:
                    Debug.Log("death");
                    break;

            }
        }
	
	}
}
