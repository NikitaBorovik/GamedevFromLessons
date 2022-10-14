using System.Collections;
using System.Collections.Generic;
using APP.Systems.Cube;
using UnityEngine;

public class App : MonoBehaviour
{
    [SerializeField]
    private CubeSystem cubeSystem;
    [SerializeField]
    private ObjectsContainer objectsContainer;

    void Start()
    {
        cubeSystem.Init(objectsContainer.Spawner.transform);
    }

    void Update()
    {
        
    }
}
