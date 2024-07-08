using EduWork.UI;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using EduWork.UI.Configurations;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.AddRootComponents();

builder.ApplyServiceConfigurations();

await builder.Build().RunAsync();
