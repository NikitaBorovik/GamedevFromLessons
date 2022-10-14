using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace APP.Systems.Cube.CubeLogic
{
    public interface ICubeSystem
    {
        public void ReportDestroyed(CubeTypes destroyedType);
    }
}
