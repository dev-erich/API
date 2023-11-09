using ErrorOr;
using LoLAPI.Contracts;
using LoLAPI.Controllers;
using LoLAPI.Models;
using LoLAPI.Services.Champions;
using Microsoft.AspNetCore.Mvc;

namespace Champions.Controllers;

public class ChampionsController : ApiController
{

	//* Constructor Dependancy injection
	private readonly IChampionService _championService;
	public ChampionsController(IChampionService championService)
	{
		_championService = championService;
	}

	//localhost:3000/champions
	[HttpPost]
	public IActionResult CreateChampion(CreateChampionRequest request)
	{
		ErrorOr<Champion> requestToChampionResult = Champion.From(request);

		if (requestToChampionResult.IsError)
		{
			return Problem(requestToChampionResult.Errors);
		}

		var champion = requestToChampionResult.Value;
		//TODO: save champion to database
		ErrorOr<Created> createChampionResult = _championService.CreateChampion(champion);

		return createChampionResult.Match(
			created => CreatedAtGetChampion(champion),
			errors => Problem(errors)
		);
	}

	//localhost:3000/champions/guid
	[HttpGet("{id:guid}")]
	public IActionResult GetChampion(Guid id)
	{
		ErrorOr<Champion> getChampionResult = _championService.GetChampion(id);

		return getChampionResult.Match(
			champion => Ok(MapChampionResponse(champion)),
			errors => Problem(errors)
		);

	}

	//localhost:3000/champions/guid
	[HttpPut("{id:guid}")]
	public IActionResult UpsertChampion(Guid id, UpsertChampionRequest request)
	{
		ErrorOr<Champion> requestToChampionResult = Champion.From(id, request);

		if (requestToChampionResult.IsError)
		{
			return Problem(requestToChampionResult.Errors);
		}

		var champion = requestToChampionResult.Value;

		ErrorOr<UpsertedChampion> upsertChampionResult = _championService.UpsetChampion(champion);

		return upsertChampionResult.Match(
			upserted => upserted.isNewlyCreated ? CreatedAtGetChampion(champion) : NoContent(),
			errors => Problem(errors)
		);
	}

	//localhost:3000/champions/guid
	[HttpDelete("{id:guid}")]
	public IActionResult DeleteChampion(Guid id)
	{
		ErrorOr<Deleted> deletedChampionResult = _championService.DeleteChampion(id);

		return deletedChampionResult.Match(
			deleted => NoContent(),
			errors => Problem(errors)
		);
	}







	private static ChampionResponse MapChampionResponse(Champion champion)
	{
		return new ChampionResponse(
			champion.Id,
			champion.Name,
			champion.Cost
		);
	}

	private IActionResult CreatedAtGetChampion(Champion champion)
	{
		return CreatedAtAction(
			actionName: nameof(GetChampion),
			routeValues: new { id = champion.Id },
			value: MapChampionResponse(champion)
			);
	}

}