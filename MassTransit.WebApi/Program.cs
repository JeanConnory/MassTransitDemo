using MassTransit;
using MassTransit.WebApi.Consumer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(cfg =>
{
	cfg.AddConsumer<OrderConsumer>();
	cfg.UsingRabbitMq((context, config) =>
	{
		config.ReceiveEndpoint("order_queue", e =>
		{
			e.ConfigureConsumer<OrderConsumer>(context);
		});
		config.Host(new Uri("rabbitmq://localhost"), h =>
		{
			h.Username("guest");
			h.Password("guest");
		});
	});
});
//builder.Services.AddMassTransitHostedService();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
