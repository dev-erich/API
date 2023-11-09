using ErrorOr;

namespace LoLAPI.ServiceErrors;

public static class Errors
{

	public static class Champion
	{
		public static Error InvalidName => Error.Validation(
			code: "Champion.InvalidName",
			description: $"Champion name must be at least {Models.Champion.MinNameLength} " +
				$"characters long and at most {Models.Champion.MaxNameLength} characters long."
		);

		public static Error InvalidBlueEssenceCost => Error.Validation(
			code: "Champion.InvalidBlueEssenceCost",
			description: $"Champion Blue Essence cost must be at least {Models.Champion.MinCost}"
		);

		public static Error InvalidRiotPointsCost => Error.Validation(
			code: "Champion.InvalidRiotPointsCost",
			description: $"Champion Riot Points cost must be at least {Models.Champion.MinCost}"
		);

		public static Error NotFound => Error.NotFound(
			code: "Champion.NotFound",
			description: "Champion not found"
		);
	}

}