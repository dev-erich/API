using ErrorOr;
using LoLAPI.Contracts;
using LoLAPI.ServiceErrors;
namespace LoLAPI.Models;

public class Champion
{
	public const int MinNameLength = 3;
	public const int MaxNameLength = 50;
	public const int MinCost = 1;

	public Guid Id { get; }
	public string Name { get; }
	public ChampionCost Cost { get; }

	private Champion(
		Guid id,
		string name,
		ChampionCost cost)
	{
		Id = id;
		Name = name;
		Cost = cost;
	}

	public static ErrorOr<Champion> Create(
		string name,
		ChampionCost cost,
		Guid? id = null
	)
	{

		List<Error> errors = new();

		if (name.Length is < MinNameLength or > MaxNameLength)
		{
			errors.Add(Errors.Champion.InvalidName);
		}

		if (cost.RiotPoints is < MinCost)
		{
			errors.Add(Errors.Champion.InvalidRiotPointsCost);
		}

		if (cost.BlueEssence is < MinCost)
		{
			errors.Add(Errors.Champion.InvalidBlueEssenceCost);
		}

		if (errors.Count > 0)
		{
			return errors;
		}

		// enforce invariants
		var champion = new Champion(
			id ?? Guid.NewGuid(),
			name,
			new ChampionCost(cost.BlueEssence, cost.RiotPoints)
		);

		return champion;
	}

	public static ErrorOr<Champion> From(CreateChampionRequest request)
	{
		return Create(
			request.Name,
			request.Cost
		);
	}

	public static ErrorOr<Champion> From(Guid id, UpsertChampionRequest request)
	{
		return Create(
			request.Name,
			request.Cost,
			id
		);
	}

}