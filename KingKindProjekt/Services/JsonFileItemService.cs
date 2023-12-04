using KingKindProjekt.Models;

namespace KingKindProjekt.Services
{
    public class JsonFileItemService : JsonFileService<Item>
    {
        public JsonFileItemService(IWebHostEnvironment webHostEnvironment) : base(webHostEnvironment)
        {
        }
    }
}
