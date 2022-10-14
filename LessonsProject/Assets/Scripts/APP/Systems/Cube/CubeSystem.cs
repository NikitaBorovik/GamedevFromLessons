using System.Collections;
using System.Collections.Generic;
using APP.Systems.Cube.CubeLogic;
using UnityEngine;

namespace APP.Systems.Cube
{
    public class CubeSystem : MonoBehaviour, ICubeSystem
    {
        #region Inspector Fields
        [SerializeField]
        private List<GameObject> cubePrefabs;

        [SerializeField]
        private int maxCubesSpawn = 5;
        #endregion

        #region Private Fields
        private Dictionary<CubeTypes, int> cubesScoreboard;

        private Transform spawner;

        private bool isInited;
        private Coroutine spawnCoroutine;

        #endregion

        #region Public Methods
        public void Init(Transform spawner)
        {
            this.spawner = spawner;
            cubesScoreboard = new Dictionary<CubeTypes, int>();
            isInited = true;
        }

        public void ReportDestroyed(CubeTypes destroyedType)
        {
            if(cubesScoreboard.ContainsKey(destroyedType) == false)
            {
                cubesScoreboard.Add(destroyedType, 0);
            }
            cubesScoreboard[destroyedType] += 1;

        }

        #endregion


        #region Private Methods
        private void ReportScoreboard()
        {
            foreach(CubeTypes key in cubesScoreboard.Keys)
            {
                //use Debug.Log to print smth in console
                Debug.Log($"Score for cube type {key}: {cubesScoreboard[key]}");
            }
        }

        //learn how it works in homework
        private IEnumerator GenerateCubes()
        {
            //random count
            int count = Random.Range(0, maxCubesSpawn);

            for(int i = 0; i < count; i++)
            {
                //random cube type
                int randomCubeType = Random.Range(0, cubePrefabs.Count - 1);

                //cube prefab instance generation on scene
                GameObject newCube = GameObject.Instantiate(cubePrefabs[randomCubeType], spawner);

                //get script on cube and init it
                BaseCube cubeScript = newCube.GetComponent<BaseCube>();
                cubeScript.Init(this);
                yield return new WaitForSeconds(0.5f);
            }
            spawnCoroutine = null;
        }
        //learn how it works in homework
        private void Update()
        {
            if (isInited)
            { 
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (spawnCoroutine == null)
                    {
                        spawnCoroutine = StartCoroutine(GenerateCubes());
                    }
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    ReportScoreboard();
                }
            }
        }
        #endregion
    }

}
