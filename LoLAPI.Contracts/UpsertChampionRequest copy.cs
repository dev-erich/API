namespace LoLAPI.Contracts;

public record DeleteChampionRequest(
	string Name,
	ChampionCost Cost
);
