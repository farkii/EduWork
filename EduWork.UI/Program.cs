using EduWork.UI;
using EduWork.UI.Core;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using EduWork.UI.Core.Configurations;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.AddRootComponents();

builder.ApplyServiceConfigurations();

await builder.Build().RunAsync();
