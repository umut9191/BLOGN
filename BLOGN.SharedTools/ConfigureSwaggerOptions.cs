using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.SharedTools
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions options)
        {
            options.AddSecurityDefinition(
                    "Bearer",new OpenApiSecurityScheme
                    {
                        Description="JWT kimlik Doğrulama için bu alanı kullanabilirsiniz. Bearer ön ekini girdikten sonra bir boşluktan sonra token girişi yapabilirsiniz" ,
                        Name ="Authorization",
                        In = ParameterLocation.Header,
                        Type= SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"  
                    });
            options.AddSecurityRequirement(
               
                new OpenApiSecurityRequirement()
                { 
                    { 
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                             Type = ReferenceType.SecurityScheme,
                             Id = "Bearer"
                        },  
                        Scheme="oauth2",
                        Name ="Bearer",
                        In= ParameterLocation.Header,
                    },
                    new List<String>()
                }
                });
            var xmlFileComment = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlFullPath = Path.Combine(AppContext.BaseDirectory,xmlFileComment);
            options.IncludeXmlComments(xmlFullPath);
        }
    }
}
