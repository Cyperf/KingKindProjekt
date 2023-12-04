using System.Text.Json;

namespace KingKindProjekt.Services
{
    public class JsonFileService<T>
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        public JsonFileService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName
        {
            get
            {
                return Path.Combine(WebHostEnvironment.WebRootPath, "Data", typeof(T).Name + ".json");
            }
        }

        public IEnumerable<T>? GetJsonItems()
        {
            if (!File.Exists(JsonFileName))
                return null;
            using (StreamReader jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<T[]>(jsonFileReader.ReadToEnd());
            }
        }

        public void SaveJsonItems(List<T> items)
        {
            using (FileStream jsonFileWriter = File.Create(JsonFileName))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(
                jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<T[]>(jsonWriter, items.ToArray());
            }
        }
    }
}
