using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace Persistence
{
    public class PersistenceSystem : MonoBehaviour
    {
        private const string FileName = "DnDSaveFile.json";
        private static readonly string Path = $"{Application.persistentDataPath}/{FileName}";
        
        /// <summary>
        /// Saves the game data to disk.
        /// </summary>
        /// <param name="gameData">The data to save.</param>
        public static void SaveGame(PersistenceModel gameData)
        {
            using (StreamWriter writer = new StreamWriter(Path, true))
            {
                writer.Write(gameData.ToJson());
            }
        }

        /// <summary>
        /// Tries to load the previously saved game data.
        /// </summary>
        /// <returns>The game data, or null if nothing has been saved, or the file has been corrupted.</returns>
        public static PersistenceModel LoadGame()
        {
            if (!File.Exists(Path)) return null;
            
            using (StreamReader reader = new StreamReader(Path))
            {
                return PersistenceModel.FromJson(reader.ReadToEnd());
            }
        }
    }
}