using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {

    public PlayerInput pi;
    public float horizontalSpeed = 100.0f;
    public float verticalSpeed = 50.0f;
    private GameObject playerHandle;
    private GameObject cameraHandle;
    private float tempEulerX = 20;
    private GameObject model;
    private GameObject camera;


    private Vector3 cameraDampSpeed;
	// Use this for initialization
	void Awake () {
        cameraHandle = transform.parent.gameObject;
        playerHandle = cameraHandle.transform.parent.gameObject;
        model = playerHandle.GetComponent<actorController>().model;
        camera = Camera.main.gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 tempModelEuler = model.transform.eulerAngles;

        playerHandle.transform.Rotate(Vector3.up, pi.Jright * horizontalSpeed * Time.fixedDeltaTime);
        //tempEulerX = cameraHandle.transform.eulerAngles.x;
        tempEulerX -= pi.Jup * -verticalSpeed * Time.fixedDeltaTime;
        tempEulerX = Mathf.Clamp(tempEulerX, -40, 30);
        //cameraHandle.transform.Rotate(Vector3.right, pi.Jup * verticalSpeed * Time.deltaTime);
        cameraHandle.transform.localEulerAngles = new Vector3(tempEulerX, 0, 0);

        model.transform.eulerAngles = tempModelEuler;

        
        camera.transform.position = Vector3.SmoothDamp(camera.transform.position, transform.position, ref cameraDampSpeed, 0.05f);
        camera.transform.eulerAngles = transform.eulerAngles;
    }

    
}
