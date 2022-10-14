using System.Collections;
using System.Collections.Generic;
using APP.Systems.Cube.CubeLogic;
using UnityEngine;

namespace APP.Systems.Cube.CubeLogic
{
    public class BlueCube : BaseCube
    {
        protected override void ReportOnDestroy()
        {
            reportingSystem.ReportDestroyed(CubeTypes.Blue);
        }
    }
}
