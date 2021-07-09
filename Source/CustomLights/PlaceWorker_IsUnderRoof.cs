using Verse;

namespace CustomLights
{
    public class PlaceWorker_IsUnderRoof : PlaceWorker
    {
        public override AcceptanceReport AllowsPlacing(BuildableDef checkingDef, IntVec3 loc, Rot4 rot, Map map,
            Thing thingToIgnore = null, Thing thing = null)
        {
            return map.roofGrid.Roofed(loc) ? true : new AcceptanceReport("IAJC.UnderRoofReport".Translate());
        }
    }
}