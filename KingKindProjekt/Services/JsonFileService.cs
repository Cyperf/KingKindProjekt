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
                //Repository<T> repository = new Repository<T>();
                //while (!jsonFileReader.EndOfStream)
                //{
                //    string key = JsonSerializer.Deserialize<string>(jsonFileReader.Read());
                //    T item = JsonSerializer.Deserialize<T>(jsonFileReader.Read());
                //    repository.Create(key, item);
                //}
                //return repository;
                return JsonSerializer.Deserialize<T[]>(jsonFileReader.ReadToEnd());
            }
        }

        public void SaveJsonItems(IEnumerable<T> items)
        {
            using (FileStream jsonFileWriter = File.Create(JsonFileName))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(
                jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                /*foreach (var temp in items.Items)
                {
                    JsonSerializer.Serialize<string>(jsonWriter, temp.Key);
                    JsonSerializer.Serialize<T>(jsonWriter, temp.Value);
                }*/
                //JsonSerializer.Serialize<string[]>(jsonWriter, items.Items.Keys.ToArray());
                JsonSerializer.Serialize<T[]>(jsonWriter, items.ToArray());
            }
        }
    }
}
