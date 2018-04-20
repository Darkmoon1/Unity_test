using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

    public Transform target;

         
    void LateUpdate()
    {
        transform.position = target.position;
    }
}
