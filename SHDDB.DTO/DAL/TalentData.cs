using SHDDB.DTO.Enums;
using System.Text.Json.Serialization;

namespace SHDDB.DTO.DAL
{
    /// <summary>
    /// Holds all talents and the metadata
    /// </summary>
    public class TalentsCollection
    {
        /// <summary>
        /// The DateTime this collection of talents was imported
        /// </summary>
        public DateTime ImportedDate { get; set; }

        /// <summary>
        /// The Patch of which this Talent set is valid for
        /// </summary>
        public string ValidFor { get; set; }

        /// <summary>
        /// The collection of talents
        /// </summary>
        public Dictionary<string, TalentData> Talents { get; set; }
    }

    /// <summary>
    /// Holds detailed talent information
    /// </summary>
    public class TalentData
    {
        /// <summary>
        /// Unique ID of this talent
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the talent
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicates the type of talent
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TalentType Type { get; set; } = TalentType.HighEnd;

        /// <summary>
        /// Description of the talent
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The values applied by this talent
        /// </summary>
        public List<TalentValueData> Values { get; set; } = [];

        /// <summary>
        /// The Slot in which this talent is present
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Slot Slot { get; set; } = Slot.None;

        /// <summary>
        /// The perfect variant of this talent if applicable
        /// </summary>
        public string? PerfectVariant { get; set; }

        /// <summary>
        /// The base talent of this talent if applicable
        /// </summary>
        public string? BaseVariant { get; set; }

        /// <summary>
        /// Indicates that this talent has modifiers
        /// </summary>
        public bool HasModifiers => HasBackpackModifier || HasChestModifier;

        /// <summary>
        /// Indicates that this Gearset talent has a backpack modifier
        /// </summary>
        public bool HasBackpackModifier => Type == TalentType.GearsetBase && Values.Any(x => x.HasBackbackModifier);

        /// <summary>
        /// Indicates that this Gearset talent has a chest modifier
        /// </summary>
        public bool HasChestModifier => Type == TalentType.GearsetBase && Values.Any(x => x.HasChestModifier);
    }

    /// <summary>
    /// Holds details of the value that a talent provides
    /// </summary>
    public class TalentValueData
    {
        /// <summary>
        /// Initializes a new instance of <see cref="TalentValueData"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetStat"></param>
        /// <param name="condition"></param>
        /// <param name="stackingMultiplier"></param>
        /// <param name="targetMultiplier"></param>
        public TalentValueData(ContextualDouble value,
            Stat targetStat,
            string? condition = null,
            ContextualDouble? stackingMultiplier = null,
            ContextualDouble? targetMultiplier = null)
        {
            Value = value;
            TargetStat = targetStat;
            StackingMultiplier = stackingMultiplier;
            TargetMultiplier = targetMultiplier;
            Condition = condition;
            Complete = true;
        }

        /// <summary>
        /// The value
        /// </summary>
        public ContextualDouble Value { set; get; }

        /// <summary>
        /// The stat that the value targets
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Stat TargetStat { get; set; }

        /// <summary>
        /// The type of this value
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TalentValueType Type => StackingMultiplier != null ? TalentValueType.Stacking : TargetMultiplier != null ? TalentValueType.MultiTarget : TalentValueType.Flat;

        /// <summary>
        /// Indicates whether this value is applied conditionally
        /// </summary>
        public bool IsConditional => !string.IsNullOrEmpty(Condition);

        /// <summary>
        /// The criteria for the condition
        /// </summary>
        public string? Condition { get; set; }

        /// <summary>
        /// The maximum stacks of the value
        /// </summary>
        public ContextualDouble? StackingMultiplier { get; set; }

        /// <summary>
        /// The maximum targets the value is applied to
        /// </summary>
        public ContextualDouble? TargetMultiplier { get; set; }

        /// <summary>
        /// Any notes regarding this value
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Indicates that this value can be overridden by a backpack
        /// </summary>
        public bool HasBackbackModifier => Value.OverriddenBy == Slot.Backpack || StackingMultiplier?.OverriddenBy == Slot.Backpack || TargetMultiplier?.OverriddenBy == Slot.Backpack;

        /// <summary>
        /// Indicates that this value can be overridden by a chest
        /// </summary>
        public bool HasChestModifier => Value.OverriddenBy == Slot.Chest || StackingMultiplier?.OverriddenBy == Slot.Chest || TargetMultiplier?.OverriddenBy == Slot.Chest;

        public bool Complete { get; set; }

        /// <summary>
        /// Returns the <seealso cref="Value"/> for each of the available contexts
        /// </summary>
        /// <returns></returns>
        public (double @base, double? chestOverride, double? backpackOverride) GetValue()
        {
            return (Value.Base, Value.OverriddenBy == Slot.Chest ? Value.Override : default, Value.OverriddenBy == Slot.Backpack ? Value.Override : default);
        }

        /// <summary>
        /// Returns the <seealso cref="StackingMultiplier"/> for each of the available contexts
        /// </summary>
        /// <returns></returns>
        public (double @base, double? chestOverride, double? backpackOverride) GetStacks()
        {
            if (Type != TalentValueType.Stacking)
            {
                return default;
            }

            return (StackingMultiplier!.Base, StackingMultiplier.OverriddenBy == Slot.Chest ? StackingMultiplier.Override : default, StackingMultiplier.OverriddenBy == Slot.Backpack ? StackingMultiplier.Override : default);
        }

        /// <summary>
        /// Returns the <seealso cref="TargetMultiplier"/> for each of the available contexts
        /// </summary>
        /// <returns></returns>
        public (double @base, double? chestOverride, double? backpackOverride) GetTargets()
        {
            if (Type != TalentValueType.MultiTarget)
            {
                return default;
            }

            return (TargetMultiplier!.Base, TargetMultiplier.OverriddenBy == Slot.Chest ? TargetMultiplier.Override : default, TargetMultiplier.OverriddenBy == Slot.Backpack ? TargetMultiplier.Override : default);
        }
    }

    /// <summary>
    /// Base Value as a <see cref="double"/> datatype
    /// <remarks>Contextual value as applicable by a gearset slot override</remarks>
    /// </summary>
    public class ContextualDouble
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ContextualDouble"/>
        /// </summary>
        /// <param name="base">Base Value</param>
        public ContextualDouble(double @base)
        {
            Base = @base;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ContextualDouble"/>
        /// </summary>
        /// <param name="base">Base Value</param>
        /// <param name="slot">Overridden by <see cref="Slot"/></param>
        /// <param name="overriden">Overridden Value</param>
        public ContextualDouble(double @base, Slot slot, double overriden)
        {
            Base = @base;
            Override = overriden;
            OverriddenBy = slot;
        }

        /// <summary>
        /// Base Value
        /// </summary>
        public double Base { get; set; }

        /// <summary>
        /// Overridden Value.
        /// Present when <seealso cref="OverriddenBy"/> is applicable to the Gearset this <see cref="ContextualDouble"/> applies to
        /// </summary>
        public double? Override { get; set; }

        /// <summary>
        /// The Slot that overrides the Base Value.
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Slot OverriddenBy { get; set; }

        /// <summary>
        /// Attempts to return the Overridden Value if the <paramref name="slot"/> overrides it.
        /// </summary>
        /// <param name="slot">The <see cref="Slot"/> that overrides the <seealso cref="Base"/> value with the <seealso cref="Override"/> value</param>
        /// <param name="maybeOverriden"><seealso cref="Override"/> if present for the <paramref name="slot"/>, otherwise <seealso cref="Base"/></param>
        /// <returns><see langword="true"/> if overridden, <see langword="false"/> otherwise</returns>
        public bool TryGetOverride(Slot slot, out double maybeOverriden)
        {
            if (slot != OverriddenBy)
            {
                maybeOverriden = Base;
                return false;
            }

            if (Override.HasValue)
            {
                maybeOverriden = Override.Value;
            }
            else
            {
                maybeOverriden = Base;
            }

            return true;
        }
    }
}
