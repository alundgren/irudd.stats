var builder = WebApplication.CreateBuilder(args);

var uiUrl = builder.Configuration.GetValue<string>("UiUrl");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

string UiCorsPolicy = "UiApiCalls";
if (uiUrl != null)
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: UiCorsPolicy,
            policy  =>
            {
                policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins(builder.Configuration.GetValue<string>("UiUrl"))
                    .AllowCredentials();
            });
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (uiUrl != null)
{
    app.UseCors(UiCorsPolicy);    
}

app.UseHttpsRedirection();

if (uiUrl == null)
{
    app.UseDefaultFiles();
    app.UseStaticFiles();
}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();