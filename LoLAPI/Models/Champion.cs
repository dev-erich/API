using LoLAPI.Contracts;
namespace LoLAPI.Models;

public class Champion
{
	public Guid Id { get; }
	public string Name { get; }
	public ChampionCost Cost { get; }

	public Champion(
		Guid id,
		string name,
		ChampionCost cost)
	{
		Id = id;
		Name = name;
		Cost = cost;
	}

}