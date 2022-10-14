using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace APP.Systems.Cube.CubeLogic
{
    public class RedCube : BaseCube
    {
        protected override void ReportOnDestroy()
        {
            reportingSystem.ReportDestroyed(CubeTypes.Red);
        }
    }
}
