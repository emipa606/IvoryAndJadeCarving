using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace CustomLights;

public class CompProperties_CustomLights : CompProperties
{
    public readonly string graphicPath = "Candle";
    public readonly List<Vector3> lightOffsets = [];
    public readonly float lightSize = 1f;

    public CompProperties_CustomLights()
    {
        compClass = typeof(CompCustomLights);
    }
}