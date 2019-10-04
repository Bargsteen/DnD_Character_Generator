using System;
using Managers;
using Misc;
using Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Controllers
{
    public class MainMenuController : MonoBehaviour
    {
        private CharacterSheetModel _characterSheetModel;

        public void OnPlayButtonPressed() => SceneManager
            .LoadScene(SceneIndexes.LevelOneIndex);

        public void OnCreateCharacterButtonPressed() => SceneManager
            .LoadScene(SceneIndexes.CharacterCreationIndex);

        public void OnQuitButtonPressed()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}
