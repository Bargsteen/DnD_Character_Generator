using System;
using System.Collections.Generic;
using Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Models
{
    public class CharacterSheetModel
    {
        private readonly int _abilityCharisma;
        private readonly int _abilityConstitution;
        private readonly int _abilityDexterity;
        private readonly int _abilityIntelligence;
        private readonly int _abilityStrength;
        private readonly int _abilityWisdom;

        [JsonProperty]
        public string CharacterName { get; }

        [JsonProperty]
        public int AbilityCharisma => _abilityCharisma + GetModifierValueFor(Ability.Charisma);

        [JsonProperty]
        public int AbilityConstitution => _abilityConstitution + GetModifierValueFor(Ability.Constitution);

        [JsonProperty]
        public int AbilityDexterity => _abilityDexterity + GetModifierValueFor(Ability.Dexterity);

        [JsonProperty]
        public int AbilityIntelligence => _abilityIntelligence + GetModifierValueFor(Ability.Intelligence);

        [JsonProperty]
        public int AbilityStrength => _abilityStrength + GetModifierValueFor(Ability.Strength);

        [JsonProperty]
        public int AbilityWisdom => _abilityWisdom + GetModifierValueFor(Ability.Wisdom);

        [JsonProperty]
        public Race Race { get; }
    
        [JsonProperty]
        public Class Class { get; }
    
        [JsonProperty]
        public Alignment Alignment { get; }
    
        [JsonProperty]
        public int ArmorClass { get; }
    
        [JsonProperty]
        public int ExperiencePoints { get; }

        // Hit Points
        [JsonProperty]
        public int CurrentHitPoints { get; }
    
        [JsonProperty]
        public int MaxHitPoints { get; }
    
        // Speed and Jumps
        private int MovementSpeed { get; }
    
        [JsonProperty]
        public int WalkingSpeed => MovementSpeed / 2; // Rounds down, as it truncates.
    
        [JsonProperty]
        public int RunningSpeed => MovementSpeed;
    
        [JsonProperty]
        public int RunningHighJump { get; }
    
        [JsonProperty]
        public int StandingHighJump => RunningHighJump / 2;
    
        [JsonProperty]
        public List<string> Items { get; }
    
        public CharacterSheetModel(string characterName, Race race, Class class_, Alignment alignment, 
            int highestRollFromHitDice, int abilityCharisma, int abilityConstitution, int abilityDexterity, 
            int abilityIntelligence, int abilityStrength, int abilityWisdom)
        {
            CharacterName = characterName;
        
            _abilityCharisma = abilityCharisma;
            _abilityConstitution = abilityConstitution;
            _abilityDexterity = abilityDexterity;
            _abilityIntelligence = abilityIntelligence;
            _abilityStrength = abilityStrength;
            _abilityWisdom = abilityWisdom;
        
            Race = race;
            Class = class_;
            Alignment = alignment;
            ArmorClass = CalculateArmorClass();
            ExperiencePoints = 0;
            MovementSpeed = GetMovementSpeedByRace(Race);
            RunningHighJump = 3 + AbilityStrength;
            (CurrentHitPoints, MaxHitPoints) = CalculateCurrentAndMaxHitPoints(highestRollFromHitDice);
            Items = new List<string>();
        }

        public string ToJson() => JsonConvert.SerializeObject(this, Formatting.Indented, new StringEnumConverter());

        public static CharacterSheetModel FromJson(string jsonData) =>
            JsonConvert.DeserializeObject<CharacterSheetModel>(jsonData);
    
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

        public static DieType GetHitDieTypeByClass(Class class_)
        {
            switch (class_)
            {
                case Class.Sorcerer: case Class.Wizard:
                    return DieType.D6;
                case Class.Bard: case Class.Cleric: case Class.Druid: case Class.Monk: case Class.Rogue: case Class.Warlock:
                    return DieType.D8;
                case Class.Fighter: case Class.Paladin: case Class.Ranger:
                    return DieType.D10;
                case Class.Barbarian:
                    return DieType.D12;
                default:
                    throw new ArgumentOutOfRangeException(nameof(class_), class_, null);
            }
        }
    
        private static int GetMovementSpeedByRace(Race race)
        {
            switch (race)
            {
                case Race.Halfling: case Race.Dwarf: case Race.Gnome: case Race.HalfElf:
                    return 25;
                case Race.Dragonborn: case Race.Elf: case Race.HalfOrc: case Race.Human: case Race.Tiefling:
                    return 30;
                default:
                    throw new ArgumentOutOfRangeException(nameof(race), race, null);
            }
        }
    }
}