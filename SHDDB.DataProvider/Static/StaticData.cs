using SHDDB.DTO.DAL;
using SHDDB.DTO.Enums;

namespace SHDDB.DataProvider.Static
{
    /// <summary>
    /// A persisted collection of talents
    /// </summary>
    public static class StaticData
    {
        /// <summary>
        /// All talents used for LINQ lookups
        /// </summary>
        public static readonly IEnumerable<TalentData> Talents = [
            #region Gearset
            new () {
                Name = "Strikers Battlegear",
                Type = TalentType.GearsetBase,
                Values = [
                    new(
                        value: new(0.0065, Slot.Backpack, 0.009),
                        targetStat: Stat.AMP,
                        stackingMultiplier: new(100, Slot.Chest, 200)
                    )
                ]
            },

            new() {
                Name = "True Patriot",
                Type = TalentType.GearsetBase,
                Values = [new(new(0.08, Slot.Backpack, 0.12), Stat.AMP)]
            },

            new()
            {
                Name = "Future Initiative",
                Type = TalentType.GearsetBase,
                Values = [new(new(0.15, Slot.Chest, 0.25), Stat.AMP)]
            },

            new()
            {
                Name = "Heartbreaker",
                Type = TalentType.GearsetBase,
                Values = [new(new(0.011), Stat.AMP, stackingMultiplier: new(50, Slot.Chest, 100))]
            },

            new()
            {
                Name = "Umbra Initiative",
                Type = TalentType.GearsetBase,
                Values = [
                    new(
                        new(0.012),
                        Stat.CHD,
                        stackingMultiplier: new(50, Slot.Chest, 100)
                    ),
                    new(
                        new(0.004),
                        Stat.RPM, // TODO: RPM calc 
                        stackingMultiplier: new(50, Slot.Chest, 100)
                    )
                ]
            },

            new()
            {
                Name = "Hunters Fury",
                Type = TalentType.GearsetBase,
                Values = [new(new(0.05), Stat.AMP, stackingMultiplier: new(5)),
                    new(new(0.2), Stat.AMP, condition: "To enemies within 15m")]
            },

            new()
            {
                Name = "Negotiators Dilemma",
                Type = TalentType.GearsetBase,
                Values = [
                    new(
                        value: new(0.6,
                            Slot.Backpack,
                            1.12),
                        Stat.TargetCount,
                        targetMultiplier: new(3,
                                Slot.Chest,
                                5),
                    condition: "On critical hit"),
                    new(
                        new(0.02),
                        Stat.CHD,
                        stackingMultiplier: new(20),
                        condition: "When marked target dies")
                ]
            },

            new()
            {
                Name = "Ongoing Directive",
                Type = TalentType.GearsetBase,
                Values = [
                    new(
                        new(0.2, Slot.Chest, 0.5),
                        Stat.AMP,
                        condition: "With Hollow-Point Ammo")
                    ]
            },

            new()
            {
                Name = "Eclipse Protocol",
                Type = TalentType.GearsetBase,
                Values = [
                    new(
                        new(0.3), Stat.AMP, condition: "To status effected targets")
                    ]
            },

            // TODO: Breaking Point

            // TODO: Vituoso

            // TODO: Hotshot

            #endregion

            #region Weapon
            new()
            {
                Name = "Flatline",
                Values = [new(new(0.15), Stat.AMP, condition: "To pulsed targets")],
                Slot = Slot.Weapon,
                PerfectVariant = "Perfect Flatline"
            },

            new()
            {
                Name = "Perfect Flatline",
                Values = [new(new(0.2), Stat.AMP, condition: "To pulsed targets")],
                Slot = Slot.Weapon,
                Type = TalentType.Perfect,
                BaseVariant = "Flatline"
            },

            new()
            {
                Name = "Optimist",
                // TODO: Perfect variant
                // TODO: Check values
                Values = [new(new(0.1575), Stat.WD) {
                    Note = "Average of 3.5% multiplied by 9 (90% Ammo capacity)",
                    Complete = false
                }],
                Slot = Slot.Weapon,
                PerfectVariant = "Perfect Optimist"
            },

            new()
            {
                Name = "Perfect Optimist",
                // TODO: Perfect variant
                // TODO: Check values
                Values = [new(new(0.2025), Stat.WD) {
                    Note = "Average of 4.5% multiplied by 9 (90% Ammo capacity)",
                    Complete = false
                }],
                Type = TalentType.Perfect,
                Slot = Slot.Weapon,
                BaseVariant = "Optimist"
            },

            new()
            {
                Name = "Strained",
                // TODO: Need new value calc for this, this is wrong
                Values = [new(new(0.5), Stat.CHD) {
                    Complete = false
                }],
                Slot = Slot.Weapon
            },

            new()
            {
                Name = "Fast Hands",
                Values = [new(new(0.04), Stat.ReloadSpeed, stackingMultiplier: new(40))],
                Slot = Slot.Weapon
            },

            new()
            {
                Name = "Scorpio",
                Values = [new(new(0.2), Stat.AMP)],
                Type = TalentType.Exotic,
                Slot = Slot.Weapon
            },

            new()
            {
                Name = "Lady Death",
                Values = [new(new(0.75), Stat.AMP, condition: "When a bullet consumes a stack")],
                Type = TalentType.Exotic,
                Slot = Slot.Weapon
            },

            new()
            {
                Name = "Backfire",
                Values = [new(new(0.01), Stat.CHD, stackingMultiplier: new(200))],
                Type = TalentType.Exotic,
                Slot = Slot.Weapon
            },

            new()
            {
                Name = "Strega",
                Values = [new(new(0.15), Stat.AMP, stackingMultiplier: new(-1), condition: "To marked enemies (Mark applied when killing an enemy within 20m)")],
                Type = TalentType.Exotic,
                Slot = Slot.Weapon
            },

            new(){
                Name = "Killer",
                Values = [new(new(0.7), Stat.CHD, condition: "For 10s after killing an enemy")],
                Type = TalentType.HighEnd,
                Slot = Slot.Weapon,
                PerfectVariant = "Perfect Killer"
            },

            new(){
                Name = "Perfect Killer",
                Values = [new(new(0.9), Stat.CHD, condition: "For 10s after killing an enemey")],
                Type = TalentType.Perfect,
                Slot = Slot.Weapon,
                BaseVariant = "Killer"
            },

            new(){
                Name = "Close & Personal",
                Values = [new(new(0.3), Stat.WD, condition: "For 10s after killing an enemy within 7m")],
                Type = TalentType.HighEnd,
                Slot = Slot.Weapon,
                PerfectVariant = "Perfectly Close and Personal"
            },

            new(){
                Name = "Perfectly Close & Personal",
                Values = [new(new(0.38), Stat.WD, condition: "For 10s after killing an enemy within 7m")],
                Type = TalentType.Perfect,
                Slot = Slot.Weapon,
                BaseVariant = "Close and Personal"
            },

            new()
            {
                Name = "Sadist",
                Values = [new(new(0.30), Stat.AMP, condition: "To bleeding enemies")],
                Type = TalentType.HighEnd,
                Slot = Slot.Weapon,
                PerfectVariant = "Perfect Sadist"
            },

            new()
            {
                Name = "Perfect Sadist",
                Values = [new(new(0.35), Stat.AMP, condition: "To bleeding enemies")],
                Slot = Slot.Weapon,
                Type = TalentType.Perfect,
                BaseVariant = "Sadist"
            },

            new()
            {
                Name = "Eyeless",
                Values = [new(new(0.30), Stat.AMP, condition: "To blinded enemies")],
                Type = TalentType.HighEnd,
                Slot = Slot.Weapon,
                PerfectVariant = "Perfect Eyeless"
            },

            new()
            {
                Name = "Perfect Eyeless",
                Values = [new(new(0.35), Stat.AMP, condition: "To blinded enemies")],
                Slot = Slot.Weapon,
                Type = TalentType.Perfect,
                BaseVariant = "Eyeless"
            },

            new()
            {
                Name = "Ignited",
                Values = [new(new(0.30), Stat.AMP, condition: "To burning enemies")],
                Type = TalentType.HighEnd,
                Slot = Slot.Weapon,
                PerfectVariant = "Perfect Ignited"
            },

            new()
            {
                Name = "Perfect Ignited",
                Values = [new(new(0.35), Stat.AMP, condition: "To burning enemies")],
                Slot = Slot.Weapon,
                Type = TalentType.Perfect,
                BaseVariant = "Ignited"
            },

            new()
            {
                Name = "Vindictive",
                Values = [new(new(0.16), Stat.CHC, condition: "For 20s after killing an enemy effected by a status within 15m"),
                    new(new(0.16), Stat.CHD, condition: "For 20s after killing an enemy effected by a status within 15m")],
                Type = TalentType.HighEnd,
                Slot = Slot.Weapon,
                PerfectVariant = "Perfect Vindictive"
            },

            new()
            {
                Name = "Perfect Vindictive",
                Values = [new(new(0.21), Stat.CHC, condition: "For 20s after killing an enemy effected by a status within 20m"),
                    new(new(0.21), Stat.CHD, condition: "For 20s after killing an enemy effected by a status within 20m")],
                Type = TalentType.Perfect,
                Slot = Slot.Weapon,
                BaseVariant = "Vindictive"
            },

            new()
            {
                Name = "In Sync",
                Values = [new(new(0.15), Stat.WD, condition: "For 5s when damaging an enemy with a skill")],
                // TODO: Skill damage and doubled bonus
                Type = TalentType.HighEnd,
                Slot = Slot.Weapon,
                PerfectVariant = "Perfectly In Sync"
            },

            new()
            {
                Name = "Perfectly In Sync",
                Values = [new(new(0.20), Stat.WD, condition: "For 5s when damaging an enemy with a skill") {
                    Note = "Doubled and Skill Damage bonuses incomplete",
                    Complete = false
                }],
                // TODO: Skill damage and doubled bonus
                Slot = Slot.Weapon,
                Type = TalentType.Perfect,
                BaseVariant = "In Sync"
            },

            // TODO: Ranger calc

            new(){
                Name = "Rifleman",
                Values = [new(new(0.1), Stat.WD, condition: "For 5s when landing a headshot - duration refreshes on headshot", stackingMultiplier: new(5))],
                Slot = Slot.Rifle,
                Type = TalentType.HighEnd,
                PerfectVariant = "Perfect Rifleman"
            },
            new(){
                Name = "Perfect Rifleman",
                Values = [new(new(0.11), Stat.WD, condition: "For 5s when landing a headshot - duration refreshes on headshot", stackingMultiplier: new(6))],
                Slot = Slot.Rifle,
                Type = TalentType.Perfect,
                BaseVariant = "Rifleman"
            },

            // TODO: Calc boomerang

            new()
            {
                Name = "Behind You",
                Values = [new(new(0.20), Stat.AMP, condition: "To enemies not targeting you")],
                Type = TalentType.HighEnd,
                Slot = Slot.Weapon,
                PerfectVariant = "Perfectly Behind You"
            },

            new()
            {
                Name = "Perfectly Behind You",
                Values = [new(new(0.20), Stat.AMP, condition: "To enemies not targeting you")],
                Slot = Slot.Weapon,
                Type = TalentType.Perfect,
                BaseVariant = "Behind You"
            },

            new(){
                Name = "Unhinged",
                Values = [new(new(0.18), Stat.WD, condition: "For LMG")],
                Slot = Slot.Weapon,
                PerfectVariant = "Perfect Unhinged"
            },

            new(){
                Name = "Perfect Unhinged",
                Values = [new(new(0.22), Stat.WD, condition: "For LMG")],
                Slot = Slot.Weapon,
                BaseVariant = "Unhinged"
            },

            new(){
                Name = "Overwhelm",
                Values = [new(new(0.1), Stat.WD, condition: "For LMG: After suppressing an enemy")],
                Slot = Slot.Weapon,
                Type = TalentType.HighEnd,
                PerfectVariant = "Perfect Overwhelm"
            },

            new(){
                Name = "Perfect Overwhelm",
                Values = [new(new(0.12), Stat.WD, condition: "For LMG: After suppressing an enemy")],
                Slot = Slot.Weapon,
                Type = TalentType.Perfect,
                BaseVariant = "Overwhelm"
            },

            new(){
                Name = "Pummel",
                Values = [new(new(0.4), Stat.WD, condition: "For Shotguns: After 3 consecutive kills")],
                Slot = Slot.Weapon,
                PerfectVariant = "Perfect Pummel"
            },

            new(){
                Name = "Perfect Pummel",
                Values = [new(new(0.4), Stat.WD, condition: "For Shotguns: After 2 consecutive kills")],
                Slot = Slot.Weapon,
                Type = TalentType.Perfect,
                BaseVariant = "Pummel"
            },

            new(){
                Name = "Pumped Up",
                Values = [new(new(0.012), Stat.WD, stackingMultiplier: new(25), condition: "For Shotguns: For 10s after reloading")],
                Slot = Slot.Weapon,
                PerfectVariant = "Perfect Pumped Up"
            },

            new(){
                Name = "Perfect Pumped Up",
                Values = [new(new(0.06), Stat.WD, stackingMultiplier: new(5), condition: "For Shotguns: For 10s after reloading")],
                Slot = Slot.Weapon,
                Type = TalentType.Perfect,
                BaseVariant = "Pumped Up"
            },

            // TODO: Brazen

            // TODO: Measured

            // TODO: Naked

            // TODO: Perfectly Naked

            // TODO: Precision Strike

            #endregion

            #region Chest

            new(){
                Name = "Gunslinger",
                Values = [new(new(0.23), Stat.TWD, condition: "For 5s after swapping weapon")],
                Slot = Slot.Chest
            },

            new(){
                Name = "Spark",
                Values = [new(new(0.15), Stat.TWD, condition: "For 15s after damaging with a skill")],
                Slot = Slot.Chest,
                PerfectVariant = "Perfect Spark"
            },

            new(){
                Name = "Perfect Spark",
                Values = [new(new(0.18), Stat.TWD, condition: "For 20s after damaging with a skill")],
                Slot = Slot.Chest,
                Type = TalentType.Perfect,
                BaseVariant = "Spark"
            },

            new()
            {
                Name = "Obliterate",
                Values = [new(new(0.01), Stat.TWD, stackingMultiplier: new(20))],
                Slot = Slot.Chest
            },

            new(){
                Name = "Intimidate",
                Values = [new(new(0.04), Stat.AMP, stackingMultiplier: new(9), condition: "While you have bonus armor") {
                    Note = "Does not match in-game text - AMP vs TWD"
                }],
                Slot = Slot.Chest,
                PerfectVariant = "Perfect Intimidate"
            },

            new(){
                Name = "Perfect Intimidate",
                Values = [new(new(0.04), Stat.AMP, stackingMultiplier: new(10), condition: "While you have bonus armor") {
                    Note = "Does not match in-game text - AMP per stack vs TWD"
                }],
                Slot = Slot.Chest,
                Type = TalentType.Perfect,
                BaseVariant = "Intimidate"
            },

            new()
            {
                Name = "Spotter",
                Values = [new(new(0.15), Stat.AMP, condition: "To pulsed targets")],
                Slot = Slot.Chest,
                Type = TalentType.HighEnd,
                PerfectVariant = "Perfect Spotter"
            },

            new()
            {
                Name = "Perfect Spotter",
                Values = [new(new(0.2), Stat.AMP, condition: "To pulsed targets")],
                Slot = Slot.Chest,
                Type = TalentType.Perfect,
                BaseVariant = "Spotter"
            },

            new()
            {
                Name = "Focus",
                Values = [new(new(0.05), Stat.TWD, stackingMultiplier: new(10), condition: "When scoped > 8x")],
                Slot = Slot.Chest,
                PerfectVariant = "Perfect Focus"
            },

            new()
            {
                Name = "Perfect Focus",
                Values = [new(new(0.06), Stat.TWD, stackingMultiplier: new(10), condition: "When scoped > 8x")],
                Slot = Slot.Chest,
                Type = TalentType.Perfect,
                BaseVariant = "Focus"
            },

            new()
            {
                Name = "Glass Cannon",
                Values = [new(new(0.25), Stat.AMP)],
                Slot = Slot.Chest,
                PerfectVariant = "Perfect Glass Cannon"
            },

            new()
            {
                Name = "Perfect Glass Cannon",
                Values = [new(new(0.30), Stat.AMP)],
                Slot = Slot.Chest,
                Type = TalentType.Perfect,
                BaseVariant = "Glass Cannon"
            },

            new(){
                Name = "Overwatch",
                Values = [new(new(0.12), Stat.TWD, condition: "After in cover for 10s, and while in cover, or in cover-to-cover")],
                Slot = Slot.Chest,
                PerfectVariant = "Perfect Overwatch"
            },

            new(){
                Name = "Perfect Overwatch",
                Values = [new(new(0.14), Stat.TWD, condition: "After in cover for 8s, and while in cover, or in cover-to-cover")],
                Slot = Slot.Chest,
                Type = TalentType.Perfect,
                BaseVariant = "Overwatch"
            },

            #endregion

            #region Backpack

            new()
            {
                Name = "Vigilance",
                Values = [new(new(0.25), Stat.TWD, condition: "After taking no damage for 4s")],
                Slot = Slot.Backpack,
                PerfectVariant = "Perfect Vigilance"
            },

            new()
            {
                Name = "Perfect Vigilance",
                Values = [new(new(0.25), Stat.TWD, condition: "After taking no damage for 3s")],
                Slot = Slot.Backpack,
                Type = TalentType.Perfect,
                BaseVariant = "Vigilance"
            },

            new()
            {
                Name = "Wicked",
                Values = [new(new(0.18), Stat.TWD, condition: "For 25s after applying a status effect")],
                Slot = Slot.Backpack,
                PerfectVariant = "Perfectly Wicked"
            },

            new()
            {
                Name = "Perfectly Wicked",
                Values = [new(new(0.18), Stat.TWD, condition: "For 27s after applying a status effect")],
                Slot = Slot.Backpack,
                Type = TalentType.Perfect,
                BaseVariant = "Wicked"
            },

            new()
            {
                Name = "Companion",
                Values = [new(new(0.15), Stat.TWD, condition: "When within 5m of an ally or skill")],
                Slot = Slot.Backpack,
                PerfectVariant = "Perfect Companion"
            },

            new()
            {
                Name = "Perfect Companion",
                Values = [new(new(0.20), Stat.TWD, condition: "When within 5m of an ally or skill")],
                Slot = Slot.Backpack,
                Type = TalentType.Perfect,
                BaseVariant = "Companion"
            },

            new()
            {
                Name = "Composure",
                Values = [new(new(0.15), Stat.TWD)],
                Slot = Slot.Backpack,
            },

            new(){
                Name = "Concussion",
                Values = [
                    new(new(0.1), Stat.TWD, condition: "For 1.5s after headshot (For 5s after headshot with MMR)"),
                    new(new(0.15), Stat.TWD, condition: "For 15s after headshot kill")
                ],
                Slot = Slot.Backpack
            },

            new()
            {
                Name = "Unstoppable Force",
                Values = [new(new(0.05), Stat.TWD, stackingMultiplier: new(5), condition: "For 15s after killing an enemy")],
                Slot = Slot.Backpack,
                PerfectVariant = "Perfectly Unstoppable Force"
            },
            new()
            {
                Name = "Perfectly Unstoppable Force",
                Values = [new(new(0.07), Stat.TWD, stackingMultiplier: new(5), condition: "For 15s after killing an enemy")],
                Slot = Slot.Backpack,
                Type = TalentType.Perfect,
                BaseVariant = "Unstoppable Force"
            },

            new()
            {
                Name = "Opportunistic",
                Values = [new(new(0.10), Stat.AMP, condition: "To the target for 5s after hitting with a Shotgun or MMR")],
                Slot = Slot.Backpack,
                PerfectVariant = "Perfectly Opportunistic"
            },

            new()
            {
                Name = "Perfectly Opportunistic",
                Values = [new(new(0.15), Stat.AMP, condition: "To the target for 5s after hitting with a Shotgun or MMR")],
                Slot = Slot.Backpack,
                Type = TalentType.Perfect,
                BaseVariant = "Opportunistic"
            }

            #endregion
        ];
    }
}
