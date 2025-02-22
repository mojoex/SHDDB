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
    }
}
