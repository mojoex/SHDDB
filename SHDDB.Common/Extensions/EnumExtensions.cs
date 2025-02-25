using SHDDB.DTO.Enums;

namespace SHDDB.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string GetString(this TalentType talentType)
        {
            return talentType switch
            {
                TalentType.GearsetBase => "Gearset",
                TalentType.HighEnd => "High End",
                _ => talentType.ToString()
            };
        }

        public static string GetString(this Stat stat)
        {
            return stat switch
            {
                Stat.ReloadSpeed => "Reload Speed",
                Stat.TargetCount => "Multi Target",
                _ => stat.ToString()
            };
        }

        public static bool IsUtility(this Stat stat)
        {
            return stat switch
            {
                Stat.ReloadSpeed => true,
                Stat.TargetCount => true,
                Stat.RPM => true,
                _ => false
            };
        }
    }
}
