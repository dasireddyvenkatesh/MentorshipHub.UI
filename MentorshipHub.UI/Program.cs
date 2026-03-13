using FluentValidation;
using MentorshipHub.UI.BusinessLayer.Classes.APICalls;
using MentorshipHub.UI.BusinessLayer.Classes.Auth;
using MentorshipHub.UI.BusinessLayer.Classes.Common;
using MentorshipHub.UI.BusinessLayer.Interfaces.APICalls;
using MentorshipHub.UI.BusinessLayer.Interfaces.Auth;
using MentorshipHub.UI.BusinessLayer.Interfaces.Common;
using MentorshipHub.UI.Components;
using MentorshipHub.UI.Validators;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"];

builder.Services.AddHttpClient<IApiClient, ApiClient>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
    client.Timeout = TimeSpan.FromMinutes(1);

}).ConfigurePrimaryHttpMessageHandler(() =>
    new HttpClientHandler
    {
        UseCookies = true
    });

builder.Services.AddSingleton<ITokenService, TokenService>();
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
builder.Services.AddSingleton<VisitCounterService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<JwtAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp =>
    sp.GetRequiredService<JwtAuthStateProvider>());
builder.Services.AddCascadingAuthenticationState();

var app = builder.Build();

app.Use(async (context, next) =>
{
    context.Response.Headers.Remove("X-Frame-Options");
    await next();
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
