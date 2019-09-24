using System.Collections.Generic;
using UnityEngine;

public class Model
{
    public string CharacterName { get; set; }
    public Dictionary<Ability, int> Abilities { get; set; }
    public Race Race { get; set; }
    public Class Class { get; set; }
    public Alignment Alignment { get; set; }
    public int ArmorClass { get; set; }
    
    // Experience Points
    public int CurrentExperiencePoints { get; set; }
    public int MaxExperiencePoints { get; set; }
    
    
    // Hit Points
    public int CurrentHitPoints { get; set; }
    public int MaxHitPoints { get; set; }
    
    // Speed
    public int WalkingSpeed { get; set; }
    public int RunningSpeed { get; set; }
    public int JumpHeight { get; set; }
    
    public Dictionary<string, object> Items { get; set; }

    public string ToJson() => JsonUtility.ToJson(this);
}

[System.Serializable]
public enum Ability
{
    Strength,
    Dexterity,
    Constitution,
    Intelligence,
    Wisdom,
    Charisma,
}

// TODO: Create friendly strings with extension method
[System.Serializable]
public enum Alignment
{
    LawfulGood,
    NeutralGood,
    ChaoticGood,
    LawfulNeutral,
    Neutral,
    ChaoticNeutral,
    LawfulEvil,
    NeutralEvil,
    ChaoticEvil,
}

[System.Serializable]
public enum Race
{
    Dragonborn,
    Dwarf,
    Elf,
    Gnome,
    HalfElf,
    HalfOrc,
    Halfling,
    Human,
    Tiefling,
}

[System.Serializable]
public enum Class
{
    Barbarian,
    Bard,
    Cleric,
    Druid,
    Fighter,
    Monk,
    Paladin,
    Ranger,
    Rogue,
    Sorcerer,
    Warlock,
    Wizard,
}