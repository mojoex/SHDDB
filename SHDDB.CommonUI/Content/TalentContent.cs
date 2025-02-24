using SHDDB.Common.Constants;
using SHDDB.Common.Extensions;
using SHDDB.DTO.DAL;
using SHDDB.DTO.Enums;
using System.Text;

namespace SHDDB.CommonUI.Content
{
    public static class TalentContent
    {
        public static string GetTalentSummary(List<TalentValueData> talentValues)
        {
            List<string> valueSummary = [];
            foreach (var value in talentValues)
            {
                if (value.Type == TalentValueType.MultiTarget)
                {
                    valueSummary.Add(value.TargetStat.GetString());
                }
                else
                {
                    valueSummary.Add($"{(value.IsConditional ? "Conditional " : string.Empty)}{value.Type} {value.TargetStat.GetString()}");
                }
            }

            return string.Join(" + ", valueSummary);
        }

        public static string GetValueForBody(TalentValueData value, bool chestModifierEnable = false, bool backpackModifierEnabled = false)
        {
            if (value.TargetStat == Stat.ReloadSpeed)
            {
                return $"{Emojis.Reload} -{GetStringValue(value)}% reload speed{GetFlatOrStackingString(value)}";
            }

            if (value.TargetStat == Stat.TargetCount)
            {
                return $"{Emojis.MultiTarget} Transfer {GetStringValue(value)}% damage dealt to up to {GetMultiTargetStringValue(value)} marked targets ";
            }

            if (value.TargetStat == Stat.AMP)
            {
                return $"{Emojis.Damage} Amplify by {GetStringValue(value)}%{GetFlatOrStackingString(value)}";
            }

            return $"{Emojis.Damage} +{GetStringValue(value)}% added {value.TargetStat}{GetFlatOrStackingString(value)}";
        }

        private static string GetStringValue(TalentValueData value, bool chestModifierEnabled = false, bool backpackModifierEnabled = false)
        {
            var (baseValue, chestValue, backpackValue) = value.GetValue();

            if (chestModifierEnabled && chestValue.HasValue)
            {
                return $"<span style=\"color:#02ee68;\">{Math.Round(chestValue.Value * 100, 2)}</span>";
            }

            if (backpackModifierEnabled && backpackValue.HasValue)
            {
                return $"<span style=\"color:#02ee68;\">{Math.Round(backpackValue.Value * 100, 2)}</span>";
            }

            return Math.Round(baseValue * 100, 2).ToString();
        }

        private static string GetMultiTargetStringValue(TalentValueData value, bool chestModifierEnabled = false, bool backpackModifierEnabled = false)
        {
            var (baseValue, chestValue, backpackValue) = value.GetTargets();

            if (chestModifierEnabled && chestValue.HasValue)
            {
                return $"<span class=\"overridden-value\">{chestValue.Value}</span>";
            }

            if (backpackModifierEnabled && backpackValue.HasValue)
            {
                return $"<span class=\"overridden-value\">{backpackValue.Value}</span>";
            }

            return baseValue.ToString();
        }

        private static string GetFlatOrStackingString(TalentValueData value, bool chestModifierEnabled = false, bool backpackModifierEnabled = false)
        {
            if (value.Type != TalentValueType.Stacking)
            {
                return string.Empty;
            }

            var (baseValue, chestValue, backpackValue) = value.GetStacks();

            if (chestModifierEnabled && chestValue.HasValue)
            {
                return $" per stack, to a max of <span class=\"overridden-value\">{chestValue.Value}</span> stacks";
            }

            if (backpackModifierEnabled && backpackValue.HasValue)
            {
                return $" per stack, to a max of <span class=\"overridden-value\">{backpackValue.Value}</span> stacks";
            }

            return baseValue == -1 ? " per stack, stacking infinitely" : $" per stack, to a max of {baseValue} stacks";
        }
    }
}
