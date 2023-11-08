namespace LoLAPI.Contracts;

public record CreateChampionRequest(
	string Name,
	ChampionCost Cost
);
