namespace LoLAPI.Contracts;

public record UpsertChampionRequest(
	string Name,
	ChampionCost Cost
);
