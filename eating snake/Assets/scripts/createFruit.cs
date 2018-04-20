using UnityEngine;
using System.Collections;

public class createFruit : MonoBehaviour {
    public GameObject fruit;
    public GameObject Timer;
    private timer fruitTimer;
    private float createTime;
    private float boxSize;
    private GameObject newFruit;
    // Use this for initialization
    void Start () {
        fruitTimer = Instantiate(Timer).GetComponent<timer>();
        createTime = 4.0f;
        boxSize = 0.3f;
        fruitTimer.createtimer(createTime);
	}
	
	// Update is called once per frame
	void Update () {
        if (fruitTimer.timeOut)
        {
            int fx = (int)Random.Range(-14, 14);
            int fy = (int)Random.Range(-10, 10);
            newFruit = Instantiate(fruit);
            newFruit.transform.position = new Vector3(fx * boxSize, fy * boxSize, 0);
            fruitTimer.resettimer();
        }
	
	}
}
