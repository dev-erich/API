using LoLAPI.Models;
using LoLAPI.Services.Champions;

namespace LoLAPI.Services.Champions;

public class ChampionService : IChampionService
{

	private static readonly Dictionary<Guid, Champion> _champions = new();
	public void CreateChampion(Champion champion)
	{
		_champions.Add(champion.Id, champion);
	}

	public void DeleteChampion(Guid id)
	{
		_champions.Remove(id);
	}

	public Champion GetChampion(Guid id)
	{
		return _champions[id];
	}

	public void UpsetChampion(Champion champion)
	{
		_champions[champion.Id] = champion;
	}
}
