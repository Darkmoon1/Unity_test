using UnityEngine;
using System.Collections;

public class OnGroundSenser : MonoBehaviour {

    //设置碰撞体下降
    public float offset = 0.3f;

    //胶囊碰撞体
    public CapsuleCollider capcol;
    //胶囊下部和上部向量
    private Vector3 point1;
    private Vector3 point2;
    private float radius;

	// Use this for initialization
	void Awake () {
        radius = capcol.radius * 0.5f;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        point1 = transform.position + transform.up * (radius - offset);
        point2 = transform.position + transform.up * (capcol.height-offset) + transform.up * radius;

        Collider[] colliders = Physics.OverlapCapsule(point1, point2, radius,LayerMask.GetMask("Ground"));
        if(colliders.Length!=0)
        {
            //foreach(var col in colliders)
            //{
            //    print(col.name);
            //}
            SendMessageUpwards("isGround");

        }
        else
        {
            SendMessageUpwards("isNotGround");
        }
    }
}
