using System.Collections.Generic;
using Enums;
using UnityEngine;

public class CharacterSheetModel
{
    public string CharacterName { get; set; }
    public Dictionary<Ability, int> Abilities { get; set; }
    public Race Race { get; set; }
    public Class Class { get; set; }
    public Alignment Alignment { get; set; }
    public int ArmorClass { get; set; }
    
    // Experience Points
    public int CurrentExperiencePoints { get; set; } // 0
    public int MaxExperiencePoints { get; set; } // 0
    
    
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