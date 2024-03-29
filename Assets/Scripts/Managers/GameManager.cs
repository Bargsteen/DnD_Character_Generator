﻿using System;
using Systems;
using Models;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        
        private static bool ShuttingDown { get; } = false;
        private static object Lock { get; } = new object();
        
        private CharacterSheetModel _characterSheetModel;

        public CharacterSheetModel CharacterSheetModel { get; private set; }
        
        private void Start()
        {
            TryLoadCharacterFromDisk(out _characterSheetModel);
        }

        public static GameManager Instance
        {
            get
            {
                if (ShuttingDown)
                {
                    Debug.LogWarning($"The {typeof(GameManager)} has already been destroyed. Returning null.");
                    return null;
                }

                lock (Lock)
                {
                    // If it already exists, just return it
                    if (_instance != null) return _instance;
                    
                    // Try to find an existing instance and return
                    _instance = FindObjectOfType<GameManager>();
                    if (_instance != null) return _instance;
                    
                    // Otherwise, create a new object, attach an instance to it, and return
                    var singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<GameManager>();
                    singletonObject.name = $"{typeof(GameManager)} (Singleton)";
                    DontDestroyOnLoad(singletonObject);
                    
                    return _instance;
                }
            }
        }
        
        /// <summary>
        /// Sets the CharacterSheetModel property and tries to save the game to disc
        /// </summary>
        /// <param name="characterModel">The model to save</param>
        public void SaveCharacterSheetModel(CharacterSheetModel characterModel)
        {
            CharacterSheetModel = characterModel;
            //PersistenceSystem.SaveGame(new PersistenceModel(_characterSheetModel));
        }
        
        /// <summary>
        /// Tries to load the character model from disk.
        /// </summary>
        /// <param name="characterModel">Contains the loaded model upon success.</param>
        /// <returns>Returns whether it successfully loaded the character</returns>
        private static bool TryLoadCharacterFromDisk(out CharacterSheetModel characterModel)
        {
            PersistenceModel gameData = PersistenceSystem.LoadGame();
            characterModel = gameData?.CharacterSheetModel;
            return characterModel != null;
        }
    }
}
