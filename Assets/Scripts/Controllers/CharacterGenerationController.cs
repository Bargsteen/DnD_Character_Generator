using System;
using DropdownControllers;
using Enums;
using Models;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Controllers
{
    public class CharacterGenerationController : MonoBehaviour
    {
        private const string EvaluationErrorMessage =
            "Entered data is invalid. Check if all fields are filled appropriately.";
        
        // Basic Properties Area
        public Text characterNameField;
        public RaceDropdownController raceDropdownController;
        public ClassDropdownController classDropdownController;
        public AlignmentDropdownController alignmentDropdownController;
        
        // Hit points area
        public Text highestRollFromHitDiceText;
        
        // Ability Area
        public Text charismaText;
        public Text constitutionText;
        public Text dexterityText;
        public Text intelligenceText;
        public Text strengthText;
        public Text wisdomText;

        public InputField jsonOutputField;

        private void Start()
        {
            raceDropdownController = FindObjectOfType<RaceDropdownController>();
            classDropdownController = FindObjectOfType<ClassDropdownController>();
            alignmentDropdownController = FindObjectOfType<AlignmentDropdownController>();

            Assert.IsTrue(raceDropdownController != null
                          && classDropdownController != null
                          && alignmentDropdownController != null);
        }

        public void TryCreateCharacterAndGenerateJson()
        {
            string characterName = characterNameField.text;
            Race race = raceDropdownController.SelectedOption;
            Class class_ = classDropdownController.SelectedOption;
            Alignment alignment = alignmentDropdownController.SelectedOption;

            int.TryParse(highestRollFromHitDiceText.text, out var highestRollFromHitDice);
            int.TryParse(charismaText.text, out var charisma);
            int.TryParse(constitutionText.text, out var constitution);
            int.TryParse(dexterityText.text, out var dexterity);
            int.TryParse(intelligenceText.text, out var intelligence);
            int.TryParse(strengthText.text, out var strength);
            int.TryParse(wisdomText.text, out var wisdom);

            // Check for any invalid data
            if (string.IsNullOrEmpty(characterName) || highestRollFromHitDice == 0 || charisma == 0 ||
                constitution == 0 || dexterity == 0 || intelligence == 0 || strength == 0 || wisdom == 0)
            {
                jsonOutputField.text = EvaluationErrorMessage;
                return;
            }
            
            var characterModel = new CharacterSheetModel(characterName, race, class_, alignment, 
                highestRollFromHitDice, charisma, constitution, dexterity, intelligence, strength, wisdom);

            jsonOutputField.text = characterModel.ToJson();
        }
    }
}
