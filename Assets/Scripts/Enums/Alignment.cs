// TODO: Create friendly strings with extension method

using System.Runtime.Serialization;

namespace Enums
{
    [System.Serializable]
    public enum Alignment
    {
        [EnumMember(Value = "Lawful Good")]
        LawfulGood,
        
        [EnumMember(Value = "Neutral Good")]
        NeutralGood,
        
        [EnumMember(Value = "Chaotic Good")]
        ChaoticGood,
        
        [EnumMember(Value = "Lawful Neutral")]
        LawfulNeutral,
        
        [EnumMember(Value = "Neutral")]
        Neutral,
        
        [EnumMember(Value = "Chaotic Neutral")]
        ChaoticNeutral,
        
        [EnumMember(Value = "Lawful Evil")]
        LawfulEvil,
        
        [EnumMember(Value = "Neutral Evil")]
        NeutralEvil,
        
        [EnumMember(Value = "Chaotic Evil")]
        ChaoticEvil,
    }
}