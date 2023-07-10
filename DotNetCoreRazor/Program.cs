using DotNetCoreRazor;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSystemWebAdapters()
    .AddJsonSessionSerializer(options =>
    {
        options.RegisterKey<string>("UserName");
        options.RegisterKey<DateTime>("CurrentTime");
    })
    .AddRemoteAppClient(options =>
    {
        options.RemoteAppUrl = new Uri(builder.Configuration["ReverseProxy:Clusters:cluster1:Destinations:destination1:Address"]!);
        options.ApiKey = builder.Configuration["RemoteSessionApiKey"]!;
    })
    .AddSessionClient();
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSystemWebAdapters();

app.UseSession();
app.UseAuthorization();
app.MapGet("/session", (HttpContext context) =>
{
    return SharedSession.GetSharedSessionObject(context);
}).RequireSystemWebAdapterSession();
app.MapRazorPages().RequireSystemWebAdapterSession();
app.MapReverseProxy();
app.Run();
