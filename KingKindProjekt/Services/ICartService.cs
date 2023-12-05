using KingKindProjekt.Models;

namespace KingKindProjekt.Services
{
	public interface ICartService
	{

		Item? GetItem(string name);
	}
}
