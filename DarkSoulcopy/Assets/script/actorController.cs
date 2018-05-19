using UnityEngine;
using System.Collections;

public class actorController : MonoBehaviour {
    public GameObject model;
    public PlayerInput pi;
    public float moveSpeed = 2.4f;
    public float runSpeed = 2.0f;
    public float rollSpeed = 1.0f;
    public float jumpSpeed = 3.5f;
    public float jadSpeed = 1.5f;

    [SerializeField]
    private Animator anim;
    private Rigidbody rigid;
    private Vector3 movingVec;
    private Vector3 thrustVector;

    private bool lockMoving = false;


	// Use this for initialization
	void Awake () {
        anim = model.GetComponent<Animator>();
        pi = GetComponent<PlayerInput>();
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame 1/60
	void Update () {
        anim.SetFloat("forward", pi.Dmag * Mathf.Lerp(anim.GetFloat("forward"), ((pi.run) ? runSpeed : 1.0f), 0.4f));
        if(pi.Dmag > 0.1f)
        {
            model.transform.forward = Vector3.Slerp(model.transform.forward, pi.Dvec, 0.3f); 
        }
        if (pi.jump)
        {
            anim.SetTrigger("jump");
        }
        if (lockMoving == false)
        {
            movingVec = pi.Dmag * model.transform.forward * moveSpeed * Mathf.Lerp(anim.GetFloat("forward"), ((pi.run) ? runSpeed : 1.0f), 0.4f);
        }
        if(rigid.velocity.magnitude > 5.0f)
        {
            anim.SetTrigger("roll");
        }

	}
    //called per frame 1/50
    void FixedUpdate(){
        rigid.velocity = new Vector3(movingVec.x, rigid.velocity.y, movingVec.z) + thrustVector;
        thrustVector = Vector3.zero;
    }
    /*
     * message processing..
     *
     **/ 
     

    public void onJumpEnter()
    {
        pi.inputEnabled = false;
        lockMoving = true;
        thrustVector = new Vector3(0, jumpSpeed, 0);
    }

    public void isGround()
    {
        anim.SetBool("isGround", true);
    }
    public void isNotGround()
    {
        pi.inputEnabled = false;
        lockMoving = true;
        anim.SetBool("isGround", false);
    }

    public void onGroundEnter()
    {
        pi.inputEnabled = true;
        lockMoving = false;
    }

    public void onRollEnter()
    {
        pi.inputEnabled = false;
        lockMoving = true;
        thrustVector = new Vector3(0, rollSpeed, 0);
    }

    //public void onJabEnter()
    //{
    //    pi.inputEnabled = false;
    //    lockMoving = true;
    //    thrustVector = model.transform.forward * -jadSpeed;
    //}

    public void onJabUpdate()
    {
        thrustVector = model.transform.forward * anim.GetFloat("jabSpeed")*jadSpeed;
    }
}
