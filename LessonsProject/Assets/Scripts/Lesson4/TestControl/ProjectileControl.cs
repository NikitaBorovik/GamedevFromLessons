using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileControl : MonoBehaviour
{
    [SerializeField]
    private float ttl = 5f;
    [SerializeField]
    private Rigidbody projectileRigidbody;
    [SerializeField]
    private float forceMultuplier = 10f;

    private void Start()
    {
        Destroy(gameObject, ttl);
        projectileRigidbody.AddForce(transform.forward * forceMultuplier);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{gameObject.name} collided with {collision.gameObject.name}");
    }
}
