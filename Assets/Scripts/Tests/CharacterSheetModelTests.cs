using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Enums;
using Models;
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
            var sut = new CharacterSheetModel("Kasper Dissing", Race.HalfElf, Class.Barbarian, 
                Alignment.ChaoticEvil, 3, 0, 1, 2, 
                3, 4, 5);
            const string expected = @"{
                            ""CharacterName"": ""Kasper Dissing"",
                            ""AbilityCharisma"": 2,
                            ""AbilityConstitution"": 3,
                            ""AbilityDexterity"": 4,
                            ""AbilityIntelligence"": 5,
                            ""AbilityStrength"": 6,
                            ""AbilityWisdom"": 7,
                            ""Race"": ""Half-Elf"",
                            ""Class"": ""Barbarian"",
                            ""Alignment"": ""Chaotic Evil"",
                            ""ArmorClass"": 12,
                            ""ExperiencePoints"": 0,
                            ""CurrentHitPoints"": 5,
                            ""MaxHitPoints"": 5,
                            ""WalkingSpeed"": 12,
                            ""RunningSpeed"": 25,
                            ""RunningHighJump"": 9,
                            ""StandingHighJump"": 4,
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
