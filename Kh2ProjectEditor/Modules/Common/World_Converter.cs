using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Dictionaries;
using System.Collections.Generic;

namespace Kh2ProjectEditor.Modules.Common
{
    public class World_Converter : BaseEnumStringConverter<World_Enum>
    {
        public World_Converter()
        {
            Options = new Dictionary<World_Enum, string>
            {
                {World_Enum.Other, "[ZZ] Other" },
                {World_Enum.EndOfSea, "[ES] End of Sea" },
                {World_Enum.TwilightTown, "[TT] Twilight Town" },
                {World_Enum.DestinyIslands, "[DI] Destiny Islands" },
                {World_Enum.HollowBastion, "[HB] Hollow Bastion" },
                {World_Enum.BeastsCastle, "[BB] Beast's Castle" },
                {World_Enum.OlympusColiseum, "[HE] Olympus Coliseum" },
                {World_Enum.Agrabah, "[AL] Agrabah" },
                {World_Enum.LandOfdragons, "[MU] Land of dragons" },
                {World_Enum.HundredAcreWood, "[PO] 100 Acre Wood" },
                {World_Enum.PrideLands, "[LK] Pride Lands" },
                {World_Enum.Atlantica, "[LM] Atlantica" },
                {World_Enum.DisneyCastle, "[DC] Disney Castle" },
                {World_Enum.TimelessRiver, "[WI] Timeless River" },
                {World_Enum.HalloweenTown, "[NM] Halloween Town" },
                {World_Enum.WorldMap, "[WM] World Map" },
                {World_Enum.PortRoyal, "[CA] Port Royal" },
                {World_Enum.SpaceParanoids, "[TR] Space Paranoids" },
                {World_Enum.TheWorldThatNeverWas, "[EH] The World that Never Was" }
            };
        }
    }
}
