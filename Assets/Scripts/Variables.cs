using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Variables
{
    private static float terrainSpeedPerSecond = 1;
    public static float TerrainSpeedPerSecond
    {
        get { return terrainSpeedPerSecond; }
        set { terrainSpeedPerSecond = value; }
    }
}
