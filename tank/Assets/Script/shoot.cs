using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

    public GameObject shell;
    public float speedUp;
    private float shootPower;
    private float resetShoot;
    public Transform shootPoint;
    private bool isFired;

    private AudioSource fireShoot;
    void Start()
    {
        fireShoot = GetComponent<AudioSource>();
        shootPower = 15.0f;
        resetShoot = shootPower;
        isFired = false;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            shootPower += speedUp * Time.deltaTime;
            if (shootPower >= 30.0f&&!isFired)
                Shoot();
        }
        if (Input.GetKeyUp(KeyCode.Space)&&!isFired)
            Shoot();
    }
    void Shoot()
    {
        isFired = true;
        GameObject newShell = Instantiate(shell, shootPoint.position, shootPoint.rotation) as GameObject;
        Rigidbody r = newShell.GetComponent<Rigidbody>();
        r.velocity = shootPoint.forward * shootPower;
        shootPower = resetShoot;
        fireShoot.Play();
        isFired = false;
    }
}
