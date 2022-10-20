using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log( $"object {other.gameObject.name} enter the trigger");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"object {other.gameObject.name} stay in trigger");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"object {other.gameObject.name} exit the trigger");
    }
}
