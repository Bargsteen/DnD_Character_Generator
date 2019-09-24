using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class CharacterSheetModel
{
    public string CharacterName { get; }
    public Dictionary<Ability, int> Abilities { get; }
    public Race Race { get; }
    public Class Class { get; }
    public Alignment Alignment { get;  }
    public int ArmorClass { get; }
    public int ExperiencePoints { get; }

    // Hit Points
    public int CurrentHitPoints { get; }
    public int MaxHitPoints { get; }
    
    // Speed and Jumps
    private int MovementSpeed { get; }
    public int WalkingSpeed => MovementSpeed / 2; // Rounds down, as it truncates.
    public int RunningSpeed => MovementSpeed;
    public int RunningHighJump => 3 + Abilities[Ability.Strength];
    public int StandingHighJump => RunningHighJump / 2;

    public Dictionary<string, object> Items { get; }
    
    public CharacterSheetModel(string characterName, Dictionary<Ability, int> abilities, Race race, Class class_, 
        Alignment alignment, int highestRollFromHitDice)
    {
        CharacterName = characterName;
        Abilities = abilities;
        Race = race;
        Class = class_;
        Alignment = alignment;
        ArmorClass = CalculateArmorClass();
        ExperiencePoints = 0;
        MovementSpeed = GetMovementSpeedByRace(Race);
        (CurrentHitPoints, MaxHitPoints) = CalculateCurrentAndMaxHitPoints(highestRollFromHitDice);
        Items = new Dictionary<string, object>();
    }

    public string ToJson() => JsonUtility.ToJson(this);

    private static int GetMovementSpeedByRace(Race race)
    {
        switch (race)
        {
            case Race.Halfling:
            case Race.Dwarf:
            case Race.Gnome:
            case Race.HalfElf:
                return 25;
            case Race.Dragonborn:
            case Race.Elf:
            case Race.HalfOrc:
            case Race.Human:
            case Race.Tiefling:
                return 30;
            default:
                throw new ArgumentOutOfRangeException(nameof(race), race, null);
        }
    }
    
    // These methods are only static until actual modifiers and items will be used.
    private static int GetModifierValueFor(Ability ability) => 2;
    private static int GetAcFromArmor() => 0;

    private static (int, int) CalculateCurrentAndMaxHitPoints(int highestRollFromHitDice)
    {
        int maxHitPoints = highestRollFromHitDice + GetModifierValueFor(Ability.Constitution);
        int currentHitPoints = maxHitPoints; // Equal to begin with
        return (currentHitPoints, maxHitPoints);
    }
    private static int CalculateArmorClass()
    {
        const int baseAc = 10;
        int dexterityModifier = GetModifierValueFor(Ability.Dexterity);
        int acFromArmor = GetAcFromArmor();
        return baseAc + dexterityModifier + acFromArmor;
    }
}

