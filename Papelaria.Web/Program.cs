using Papelaria.Web.Components;
using MudBlazor.Services;
using Papelaria.Web.Components;
using Papelaria.Web;
using Refit;


        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddMudServices();

        builder.Services
        .AddRefitClient<IApiService>()
        .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7057"));

        builder.Services.AddMudServices();



        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseAntiforgery();

        app.MapStaticAssets();
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
