using System;
using Managers;
using Misc;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Controllers
{
    public class MainMenuController : MonoBehaviour
    {
        private CharacterSheetModel _characterSheetModel;
        public Button playButton;

        public void Start()
        {
            if (playButton == null)
            {
                Debug.Log("PlayButton is null");
            }

            if (GameManager.Instance == null)
            {
                Debug.Log("GameManager is null");
            }
            playButton.enabled = GameManager.Instance.CharacterSheetModel != null;
        }

        // TODO: Use GetByName
        public void OnPlayButtonPressed() => SceneManager
            .LoadScene(2);

        public void OnCreateCharacterButtonPressed() => SceneManager
            .LoadScene(1);

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
