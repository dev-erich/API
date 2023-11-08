
using LoLAPI.Contracts;
using LoLAPI.Models;
using LoLAPI.Services.Champions;
using Microsoft.AspNetCore.Mvc;

namespace Champions.Controllers;

[ApiController]
[Route("[controller]")]
public class ChampionsController : ControllerBase
{

	//* Dependancy injection
	private readonly IChampionService _championService;
	public ChampionsController(IChampionService championService)
	{
		_championService = championService;
	}

	[HttpPost]
	public IActionResult CreateChampion(CreateChampionRequest request)
	{
		var champion = new Champion(
			Guid.NewGuid(),
			request.Name,
			request.Cost
		);

		//TODO: save champion to database
		_championService.CreateChampion(champion);

		var response = new ChampionResponse(
			champion.Id,
			champion.Name,
			champion.Cost
		);

		return CreatedAtAction(
			actionName: nameof(GetChampion),
			routeValues: new { id = champion.Id },
			value: response
			);
	}

	[HttpGet("{id:guid}")]
	public IActionResult GetChampion(Guid id)
	{
		Champion champion = _championService.GetChampion(id);

		var response = new ChampionResponse(
			champion.Id,
			champion.Name,
			champion.Cost
		);

		return Ok(response);
	}

	[HttpPut("{id:guid}")]
	public IActionResult UpsetChampion(Guid id, UpsertChampionRequest request)
	{
		var champion = new Champion(
			id,
			request.Name,
			request.Cost
		);

		_championService.UpsetChampion(champion);

		// TODO: return 201 if a new champion was created
		return NoContent();
	}

	[HttpDelete("{id:guid}")]
	public IActionResult DeleteChampion(Guid id)
	{
		_championService.DeleteChampion(id);
		return NoContent();
	}

}