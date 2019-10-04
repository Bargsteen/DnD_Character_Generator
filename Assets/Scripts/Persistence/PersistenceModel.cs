using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Persistence
{
    public class PersistenceModel
    {
        [JsonProperty]
        public CharacterSheetModel CharacterSheetModel { get;}
        public PersistenceModel(CharacterSheetModel characterSheetModel)
        {
            CharacterSheetModel = characterSheetModel;
        }

        public string ToJson() => JsonConvert.SerializeObject(this, Formatting.Indented);
        public static PersistenceModel FromJson(string jsonData) => JsonConvert.DeserializeObject<PersistenceModel>(jsonData);
    }
}