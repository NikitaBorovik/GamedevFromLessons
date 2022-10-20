using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCharacterControl : MonoBehaviour, IInputSystemListener
{
    [SerializeField]
    private Rigidbody playerRigidbody;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float turnSpeed;
    [SerializeField]
    private Transform projectileSpawner;
    [SerializeField]
    private GameObject projectile;

    public void UserMovement(Vector3 movementDirection)
    {
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World);
        if(movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
        }
    }

    public void UserClick(Vector3 position)
    {
        GameObject newProjectile = Instantiate(projectile, projectileSpawner.position, transform.rotation);
    }

}
