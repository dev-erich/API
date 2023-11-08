namespace LoLAPI.Contracts;

public record ChampionResponse(
	Guid Id,
	string Name,
	ChampionCost Cost
);
