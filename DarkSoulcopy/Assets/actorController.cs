using UnityEngine;
using System.Collections;

public class actorController : MonoBehaviour {
    public GameObject model;
    public PlayerInput pi;
    public float moveSpeed = 1.4f;

    [SerializeField]
    private Animator anim;
    private Rigidbody rigid;
    private Vector3 movingVec;

	// Use this for initialization
	void Awake () {
        anim = model.GetComponent<Animator>();
        pi = GetComponent<PlayerInput>();
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame 1/60
	void Update () {
        anim.SetFloat("forward", pi.Dmag);
        if(pi.Dmag > 0.1f)
            model.transform.forward = pi.Dvec;
        movingVec = pi.Dmag * model.transform.forward;
	}
    //called per frame 1/50
    void FixedUpdate(){
        rigid.position += movingVec * Time.fixedDeltaTime * moveSpeed;
    }
}
