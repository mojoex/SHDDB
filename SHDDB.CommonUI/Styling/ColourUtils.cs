using SHDDB.DTO.Enums;

namespace SHDDB.CommonUI.Styling
{
    public static class ColourUtils
    {
        public static string GetRarityColour(TalentType type)
        {
            return type switch
            {
                TalentType.HighEnd => "color: #FFD700;",
                TalentType.Perfect => "color: #EAA213;",
                TalentType.Exotic => "color: #ff6f36;",
                TalentType.GearsetBase => "color: #01ff90;",
                TalentType.GearsetBackpack => "color: #01ff90;",
                TalentType.GearsetChest => "color: #01ff90;",
                _ => "color: #ffaf10;"
            };
        }
    }
}
