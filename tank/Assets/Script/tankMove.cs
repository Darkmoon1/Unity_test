using UnityEngine;
using System.Collections;

public class tankMove : MonoBehaviour {

    public float moveSpeed;
    public float rotateSpeed;

    void Update()
    {
        float h = Input.GetAxis("Horizontal1");
        float v = Input.GetAxis("Vertical1");
        transform.Translate(Vector3.forward * v * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * h * rotateSpeed * Time.deltaTime);

    }
}
