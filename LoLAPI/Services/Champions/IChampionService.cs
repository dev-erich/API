using LoLAPI.Models;

namespace LoLAPI.Services.Champions;

public interface IChampionService
{
	void CreateChampion(Champion champion);
	void DeleteChampion(Guid id);
	Champion GetChampion(Guid id);
	void UpsetChampion(Champion champion);
	// ChampionResponse GetChampion(CreateChampionRequest request);
	// ChampionResponse UpdateChampion(CreateChampionRequest request);
	// ChampionResponse DeleteChampion(CreateChampionRequest request);
}