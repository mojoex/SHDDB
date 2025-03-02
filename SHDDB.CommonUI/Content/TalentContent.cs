using SHDDB.Common.Extensions;
using SHDDB.DTO.DAL;
using SHDDB.DTO.Enums;
using System.Text;

namespace SHDDB.CommonUI.Content
{
    public static class TalentContent
    {
        public static string GetValueDescription(TalentValueData value, bool useChest, bool useBackpack)
        {
            return value.ApplicationType switch
            {
                TalentValueType.Stacking => StackingDescription(value, useChest, useBackpack),
                TalentValueType.MultiTarget => MultiTargetDescription(value, useChest, useBackpack),
                _ => FlatDescription(value, useChest, useBackpack)
            };
        }

        private static string StackingDescription(TalentValueData value, bool useChest, bool useBackpack)
        {
            StringBuilder sb = new();

            var (baseValue, chestValue, backpackValue) = value.GetValue();
            var (stackingBaseValue, stackingChestValue, stackingBackpackValue) = value.GetStacks();

            if (useChest && chestValue.HasValue)
            {
                sb.Append($"<span style=\"color: #01ff90\">{chestValue.Value.AsString("%")}</span> {value.TargetStat.AsString()} per stack, to a max of ");
            }
            else if (useBackpack && backpackValue.HasValue)
            {
                sb.Append($"<span style=\"color: #01ff90\">{backpackValue.Value.AsString("%")}</span> {value.TargetStat.AsString()} per stack, to a max of ");
            }
            else
            {
                sb.Append($"{baseValue.AsString("%")} {value.TargetStat.AsString()} per stack, to a max of ");
            }

            if (useChest && stackingChestValue.HasValue)
            {
                sb.Append($"<span style=\"color: #01ff90\">{stackingChestValue.Value}</span> stacks");
            }
            else if (useBackpack && stackingBackpackValue.HasValue)
            {
                sb.Append($"<span style=\"color: #01ff90\">{stackingBackpackValue.Value}</span> stacks");
            }
            else
            {
                sb.Append($"{stackingBaseValue} stacks");
            }

            return sb.ToString();
        }

        private static string MultiTargetDescription(TalentValueData value, bool useChest, bool useBackpack)
        {
            StringBuilder sb = new();

            sb.Append("Transfer ");

            var (baseValue, chestValue, backpackValue) = value.GetValue();

            if (useChest && chestValue.HasValue)
            {
                sb.Append($"<span style=\"color: #01ff90\">{chestValue.Value.AsString("%")}</span>");
            }
            else if (useBackpack && backpackValue.HasValue)
            {
                sb.Append($"<span style=\"color: #01ff90\">{backpackValue.Value.AsString("%")}</span>");
            }
            else
            {
                sb.Append($"{baseValue.AsString("%")}");
            }

            sb.Append(" damage dealt to up to ");

            var (targetBaseValue, targetChestValue, targetBackpackValue) = value.GetTargets();

            if (useChest && targetChestValue.HasValue)
            {
                sb.Append($"<span style=\"color: #01ff90\">{targetChestValue.Value}</span>");
            }
            else if (useBackpack && targetBackpackValue.HasValue)
            {
                sb.Append($"<span style=\"color: #01ff90\">{targetBackpackValue.Value}</span>");
            }
            else
            {
                sb.Append($"{targetBaseValue}");
            }

            sb.Append(" marked targets");

            return sb.ToString();
        }

        private static string FlatDescription(TalentValueData value, bool useChest, bool useBackpack)
        {
            StringBuilder sb = new();

            var (baseValue, chestValue, backpackValue) = value.GetValue();

            if (useChest && chestValue.HasValue)
            {
                sb.Append($"<span style=\"color: #01ff90\">{chestValue.Value.AsString("%")}</span> {value.TargetStat.AsString()}");

                return sb.ToString();
            }

            if (useBackpack && backpackValue.HasValue)
            {
                sb.Append($"<span style=\"color: #01ff90\">{backpackValue.Value.AsString("%")}</span> {value.TargetStat.AsString()}");
                return sb.ToString();
            }

            sb.Append($"{baseValue.AsString("%")} {value.TargetStat.AsString()}");

            return sb.ToString();
        }
    }
}
