using EduWork.Data;
using EduWork.Domain.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using EduWork.WebAPI.Configurations;


var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);


builder.AllServiceConfigurations();

var app = builder.Build();

app.AllAppConfigurations(builder);

app.Run();
