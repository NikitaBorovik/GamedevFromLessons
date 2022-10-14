using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace APP.Systems.Cube.CubeLogic
{
    public abstract class BaseCube : MonoBehaviour
    {
        [SerializeField]
        protected CubeTypes currentCubeType;

        [SerializeField]
        protected List<CubeConfig> cubeConfigs;

        [SerializeField]
        protected Renderer objectRenderer;

        [SerializeField]
        private Rigidbody cubeRigidbody;

        [SerializeField]
        private string destroyerTag = "Destroyer";

        protected ICubeSystem reportingSystem;

        public void Init(ICubeSystem cubeSystem)
        {
            reportingSystem = cubeSystem;
            CubeConfig currentConfig = null;
            currentConfig = FindConfig();
            SetupCube(currentConfig);
        }

        private CubeConfig FindConfig()
        {
            CubeConfig currentConfig = null;
            foreach (CubeConfig config in cubeConfigs)
            {
                if (config.Type == currentCubeType)
                {
                    currentConfig = config;
                    break;
                }
            }
            if (currentConfig == null)
            {
                Debug.LogError($"Config for {currentCubeType} is missing!");
            }

            return currentConfig;
        }

        private void SetupCube(CubeConfig cubeConfig)
        {
            if(cubeConfig != null)
            {
                objectRenderer.material.color = cubeConfig.Color;
                cubeRigidbody.useGravity = true;
            }
            else
            {
                Debug.LogError($"Can't setup config for {currentCubeType}!");
                Destroy(this.gameObject);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == destroyerTag)
            {
                ReportOnDestroy();
                Destroy(this.gameObject);
            }
        }

        protected abstract void ReportOnDestroy();
    }
}

