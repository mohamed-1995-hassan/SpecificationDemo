using Microsoft.EntityFrameworkCore;
using SpecificationDemo.Core.Entities;
using SpecificationDemo.Core.Enums;
using SpecificationDemo.Infrastracure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(opt =>
{
	opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

using(var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
	if (!context.Materials.Any() && !context.Lessons.Any())
	{
		var materials = new List<Material>
		{
			new Material
			{
				Name = "Arabic Material",
				MaterialType = MaterialType.Pdf
			},
			new Material
			{
				Name = "English Material",
				MaterialType = MaterialType.Video
			}
		};
		var lesson = new Lesson
		{
			Name = "First Lesson",
			Description = "Full Description About Lesson",
			Materials = materials
		};
		context.Lessons.Add(lesson);
		context.SaveChanges();
	}

}

	app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
