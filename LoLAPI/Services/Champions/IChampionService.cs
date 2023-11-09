using LoLAPI.Models;
using ErrorOr;

namespace LoLAPI.Services.Champions;

public interface IChampionService
{
	ErrorOr<Created> CreateChampion(Champion champion);
	ErrorOr<Champion> GetChampion(Guid id);
	ErrorOr<UpsertedChampion> UpsetChampion(Champion champion);
	ErrorOr<Deleted> DeleteChampion(Guid id);
	// ChampionResponse GetChampion(CreateChampionRequest request);
	// ChampionResponse UpdateChampion(CreateChampionRequest request);
	// ChampionResponse DeleteChampion(CreateChampionRequest request);
}