using Microsoft.AspNetCore.Mvc;

namespace LoLAPI.Controllers;

public class ErrorsController : ControllerBase
{
	[Route("/error")]
	public IActionResult Error()
	{
		return Problem();
	}
}