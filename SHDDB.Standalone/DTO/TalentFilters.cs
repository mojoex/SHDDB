using SHDDB.DTO.Enums;

namespace SHDDB.Standalone.DTO
{
    public class TalentFilters
    {
        public TalentSlotFilters Slots { get; set; } = new();

        public TalentTypeFilters Types { get; set; } = new();

        public bool HasFilters => GetSlotFilters().Count > 0 || GetTypeFilters().Count > 0 || Types.Gearset;

        public List<Slot> GetSlotFilters()
        {
            List<Slot> slots = [];

            if (Slots.Weapon)
            {
                slots.Add(Slot.Weapon);
            }

            if (Slots.Backpack)
            {
                slots.Add(Slot.Backpack);
            }

            if (Slots.Chest)
            {
                slots.Add(Slot.Chest);
            }

            return slots;
        }

        public List<TalentType> GetTypeFilters()
        {
            List<TalentType> types = [];

            if (Types.HighEnd)
            {
                types.Add(TalentType.HighEnd);
            }

            if (Types.Exotic)
            {
                types.Add(TalentType.Exotic);
            }

            if (Types.Perfect)
            {
                types.Add(TalentType.Perfect);
            }

            return types;
        }
    }

    public class TalentSlotFilters
    {
        public bool Weapon { get; set; }

        public bool Backpack { get; set; }

        public bool Chest { get; set; }
    }

    public class TalentTypeFilters
    {
        public bool Gearset { get; set; }

        public bool HighEnd { get; set; }

        public bool Exotic { get; set; }

        public bool Perfect { get; set; }
    }
}
