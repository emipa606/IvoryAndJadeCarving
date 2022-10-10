using RimWorld;
using UnityEngine;
using Verse;

namespace CustomLights;

[StaticConstructorOnStartup]
public class CompCustomLights : ThingComp
{
    private CompCustomLights customLights;
    private bool lightIsOn;

    private bool ShowLights
    {
        get
        {
            if (!parent.Spawned)
            {
                return false;
            }

            var compRefuelable = parent.TryGetComp<CompRefuelable>();
            if (compRefuelable is { HasFuel: false })
            {
                return false;
            }

            var compFlickable = parent.TryGetComp<CompFlickable>();
            return compFlickable == null || compFlickable.SwitchIsOn;
        }
    }


    private CompProperties_CustomLights Props => (CompProperties_CustomLights)props;

    public override void PostExposeData()
    {
        Scribe_Values.Look(ref lightIsOn, "lightIsOn");
    }

    public override void PostSpawnSetup(bool respawningAfterLoad)
    {
        customLights = parent.TryGetComp<CompCustomLights>();
    }

    public override void PostDraw()
    {
        base.PostDraw();
        if (!ShowLights)
        {
            return;
        }

        var drawSize = new Vector2(customLights.Props.lightSize, customLights.Props.lightSize);
        var lightGraphic = GraphicDatabase.Get<Graphic_Flicker>(customLights.Props.graphicPath,
            ShaderDatabase.TransparentPostLight, drawSize, Color.white);

        foreach (var lightOffset in customLights.Props.lightOffsets)
        {
            var drawPos = parent.DrawPos + lightOffset;
            lightGraphic.Draw(drawPos.RotatedBy(parent.Rotation.AsAngle), Rot4.North, parent);
        }
    }
}