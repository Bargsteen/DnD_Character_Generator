using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
            var sut = new CharacterSheetModel("Kasper Dissing", Race.Dragonborn, Class.Barbarian, 
                Alignment.Neutral, 3, 0, 1, 2, 
                3, 4, 5);
            const string expected = @"{
                            ""CharacterName"": ""Kasper Dissing"",
                            ""Ability_Charisma"": 0,
                            ""Ability_Constitution"": 1,
                            ""Ability_Dexterity"": 2,
                            ""Ability_Intelligence"": 3,
                            ""Ability_Strength"": 4,
                            ""Ability_Wisdom"": 5,
                            ""Race"": 0,
                            ""Class"": 0,
                            ""Alignment"": 4,
                            ""ArmorClass"": 12,
                            ""ExperiencePoints"": 0,
                            ""CurrentHitPoints"": 5,
                            ""MaxHitPoints"": 5,
                            ""WalkingSpeed"": 15,
                            ""RunningSpeed"": 30,
                            ""RunningHighJump"": 7,
                            ""StandingHighJump"": 3,
                            ""Items"": []
                            }";
            
            // Act
            var actual = sut.ToJson();
            
            // Assert
            
            // Remove whitespace
            var cleanedActual = Regex.Replace(actual, @"\s+", "");
            var cleanedExpected = Regex.Replace(expected, @"\s+", "");
            
            Assert.That(cleanedActual, Is.EqualTo(cleanedExpected));
        }
    }
}
