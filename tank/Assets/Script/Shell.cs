using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {

    public GameObject explosionEffect;
    public float effectLife;
    public float explosionRadius;
    public float explosionForce;
    void OnCollisionEnter()
    {
        GameObject effect = Instantiate(explosionEffect, transform.position, transform.rotation) as GameObject;

        Destroy(gameObject);
        Destroy(effect, effectLife);
        Collider[] collider = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider hit in collider)
        {
            Rigidbody r = hit.GetComponent<Rigidbody>();
            if (r != null)
            {
                r.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
    }
}
