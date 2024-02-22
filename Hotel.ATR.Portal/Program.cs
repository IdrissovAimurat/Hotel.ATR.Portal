using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging(logging =>
{
    //logging.ClearProviders();
    //logging.AddConsole();
    //logging.AddDebug();
    //logging.AddEventLog();

    //logging.AddSeq();
    //Log.Logger = new LoggerConfiguration()
    //.WriteTo.Seq("http://localhost:5341/")
    //.CreateLogger();
}).UseSerilog();



// Add services to the container.
builder.Services.AddControllersWithViews();
Log.Logger = new LoggerConfiguration()
    .WriteTo.Seq("http://localhost:5341/")
    .CreateLogger();

     builder.Services.AddSingleton<Serilog.ILogger>(Log.Logger);


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
