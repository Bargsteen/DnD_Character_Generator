using System;
using System.Collections.Generic;
using Enums;
using NUnit.Framework;

namespace Tests
{
    public class CharacterSheetModelTests
    {
        // NAMING CONVENTION: Method_Circumstances_ExpectedOutput
        [Test]
        public void ToJson_ValidProperties_CorrectJson()
        {
            // Arrange
            var sut = new CharacterSheetModel("Kasper Dissing", new Dictionary<Ability, int>{{Ability.Strength, 2}}, Race.Dragonborn, Class.Barbarian, Alignment.Neutral, 3 );
            // Act
            var json = sut.ToJson();
            // Assert
            StringAssert.Equals(json, @"{
            ""CharacterName"": ""Kasper Dissing"",
            ""Abilities"": {
                ""Strength"": 2
            },
            ""Race"": 0,
            ""Class"": 0,
            ""Alignment"": 4,
            ""ArmorClass"": 12,
            ""ExperiencePoints"": 0,
            ""CurrentHitPoints"": 5,
            ""MaxHitPoints"": 5,
            ""WalkingSpeed"": 15,
            ""RunningSpeed"": 30,
            ""RunningHighJump"": 5,
            ""StandingHighJump"": 2,
            ""Items"": {}
        }");
        }
    }
}
