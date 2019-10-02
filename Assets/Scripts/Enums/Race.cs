using System.Runtime.Serialization;

namespace Enums
{
    [System.Serializable]
    public enum Race
    {
        Dragonborn,
        Dwarf,
        Elf,
        Gnome,
        
        [EnumMember(Value = "Half-Elf")]
        HalfElf,
        
        [EnumMember(Value = "Half-Orc")]
        HalfOrc,
        
        Halfling,
        Human,
        Tiefling,
    }
}