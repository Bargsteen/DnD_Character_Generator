using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class LevelOneController : MonoBehaviour
    {
        public Text welcomeText;

        private void Start()
        {
            var characterModel = GameManager.Instance.CharacterSheetModel;

            welcomeText.text = 
                characterModel == null 
                ? "You need to create a character first." 
                : $"You are a {characterModel.Race} {characterModel.Class} named {characterModel.CharacterName}.";
        }
    }
}
