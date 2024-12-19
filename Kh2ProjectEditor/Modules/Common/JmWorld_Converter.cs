using Kh2ProjectEditor.Utils;
using KhLib.Kh2.Dictionaries;
using System.Collections.Generic;

namespace Kh2ProjectEditor.Modules.Common
{
    public class JmWorld_Converter : BaseEnumStringConverter<JmWorld_Enum>
    {
        public JmWorld_Converter()
        {
            Options = new Dictionary<JmWorld_Enum, string>
            {
                {JmWorld_Enum.TwilightTown, "[TT] Twilight Town" },
                {JmWorld_Enum.HollowBastion, "[HB] Hollow Bastion" },
                {JmWorld_Enum.BeastsCastle, "[BB] Beast's Castle" },
                {JmWorld_Enum.OlympusColiseum, "[HE] Olympus Coliseum" },
                {JmWorld_Enum.Agrabah, "[AL] Agrabah" },
                {JmWorld_Enum.LandOfdragons, "[MU] Land of dragons" },
                {JmWorld_Enum.HundredAcreWood, "[PO] 100 Acre Wood" },
                {JmWorld_Enum.PrideLands, "[LK] Pride Lands" },
                {JmWorld_Enum.Atlantica, "[LM] Atlantica" },
                {JmWorld_Enum.DisneyCastle, "[DC] Disney Castle" },
                {JmWorld_Enum.TimelessRiver, "[WI] Timeless River" },
                {JmWorld_Enum.HalloweenTown, "[NM] Halloween Town" },
                {JmWorld_Enum.PortRoyal, "[CA] Port Royal" },
                {JmWorld_Enum.SpaceParanoids, "[TR] Space Paranoids" },
                {JmWorld_Enum.TheWorldThatNeverWas, "[EH] The World that Never Was" },
                {JmWorld_Enum.Collection, "Collection" },
                {JmWorld_Enum.Other, "Other" },
                {JmWorld_Enum.Heartless, "Heartless" },
                {JmWorld_Enum.Nobodies, "Nobodies" },
                {JmWorld_Enum.SimulatedTwilightTown, "[STT] Simulated Twilight Town" }
            };
        }
    }
}
