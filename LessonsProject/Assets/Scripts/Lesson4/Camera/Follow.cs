using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField]
    private Transform targetToFollow;

    // Update is called once per frame
    void Update()
    {
        transform.position = targetToFollow.transform.position + new Vector3(0, 5, -10);
    }
}
