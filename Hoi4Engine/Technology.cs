using System.Collections.Frozen;

namespace Hoi4Engine
{
    public class Technology
    {
        private string infantryEquipment;

        public Technology()
        {
            infantryEquipment = "infantry_equipment_0";
        }

        public string InfantryEquipment
        {
            get => infantryEquipment;
            set
            {
                if (!ValidInfantryEquipment.Contains(value))
                {
                    throw new ArgumentOutOfRangeException($"Infantry equipment type \"{value}\" is not known.");
                }
                infantryEquipment = value;
            }
        }

        public FrozenSet<string> ValidInfantryEquipment { get; } = new string[] {
            "infantry_equipment_0",
            "infantry_equipment_1",
            "infantry_equipment_2",
            "infantry_equipment_3"
        }.ToFrozenSet();
    }
}
