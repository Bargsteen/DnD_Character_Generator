using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Models
{
    public class PersistenceModel
    {
        [JsonProperty]
        public CharacterSheetModel CharacterSheetModel { get; }
        public PersistenceModel(CharacterSheetModel characterSheetModel)
        {
            CharacterSheetModel = characterSheetModel;
        }

        public string ToJson() => JsonConvert.SerializeObject(this, Formatting.Indented, new StringEnumConverter());
        public static PersistenceModel FromJson(string jsonData) => 
            JsonConvert.DeserializeObject<PersistenceModel>(jsonData, new StringEnumConverter());
    }
}