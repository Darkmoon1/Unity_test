using UnityEngine;
using System.Collections;

public class eat : MonoBehaviour {
    // Use this for initialization
    public int situation = 0;
    //0无状况 1吃水果 2死亡
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
    
   void OnTriggerEnter2D(Collider2D target)
    {
        Debug.Log(target.gameObject.name);
        switch (target.tag)
        {
            case "fruit":
                situation = 1;
                Destroy(target.gameObject);
                break;
            case "body":
                situation = 2;
                break;
        }
    }
}
