using LoLAPI.Services.Champions;

var builder = WebApplication.CreateBuilder(args);
{
	builder.Services.AddControllers();

	//? AddSingleton<>()
	//? Adds Singletin to lifetime of the server's running instance
	// builder.Services.AddSingleton<IChampionService, ChampionService>();

	//? AddScoped<>()
	//? Within the life time of a single request, any followed request will use the same object
	builder.Services.AddScoped<IChampionService, ChampionService>();
	
	//? AddTransient<>()
	//? Creates a new object everytime the ChampionService object is created
	// builder.Services.AddTransient<IChampionService, ChampionService>();
}

var app = builder.Build();
{
	app.UseExceptionHandler("/error");
	app.UseHttpsRedirection();
	app.MapControllers();
	app.Run();
}