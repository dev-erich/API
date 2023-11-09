using ErrorOr;
using LoLAPI.Models;
using LoLAPI.ServiceErrors;

namespace LoLAPI.Services.Champions;

public class ChampionService : IChampionService
{

	private static readonly Dictionary<Guid, Champion> _champions = new();
	public ErrorOr<Created> CreateChampion(Champion champion)
	{
		_champions.Add(champion.Id, champion);
		return Result.Created;
	}

	public ErrorOr<Deleted> DeleteChampion(Guid id)
	{
		_champions.Remove(id);
		return Result.Deleted;
	}

	public ErrorOr<Champion> GetChampion(Guid id)
	{
		if (_champions.TryGetValue(id, out var champion))
		{
			return _champions[id];
		}

		return Errors.Champion.NotFound;
	}

	public ErrorOr<UpsertedChampion> UpsetChampion(Champion champion)
	{
		var isNewlyCreated = !_champions.ContainsKey(champion.Id);

		_champions[champion.Id] = champion;
		return new UpsertedChampion(isNewlyCreated);
	}

}
