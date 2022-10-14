using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsContainer : MonoBehaviour
{
    [SerializeField]
    private GameObject destroyer;
    [SerializeField]
    private GameObject spawner;

    public GameObject Destroyer => destroyer;
    public GameObject Spawner => spawner;
}
