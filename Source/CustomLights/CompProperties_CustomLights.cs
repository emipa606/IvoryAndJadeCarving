using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace CustomLights;

public class CompProperties_CustomLights : CompProperties
{
    public string graphicPath = "Candle";
    public List<Vector3> lightOffsets = new List<Vector3>();
    public float lightSize = 1f;

    public CompProperties_CustomLights()
    {
        compClass = typeof(CompCustomLights);
    }
}