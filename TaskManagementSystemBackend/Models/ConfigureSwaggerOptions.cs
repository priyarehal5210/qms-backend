﻿using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TaskManagementSystemBackend.Models
{
    public class ConfigureSwaggerOptions:IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions options)
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Application Header using the Bearer Scheme\r\n\r\n" +
               "Enter 'Bearer'[space] and then your token in the text input below\r\n\r" +
               "Example :Bearer 12345abcde\r\n\r" +
               "In:Header",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            //****
            options.AddSecurityRequirement(new OpenApiSecurityRequirement() {
            {
                    new OpenApiSecurityScheme
                    {
                        Reference=new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        },
                        Scheme="oauth2",
                        Name="Bearer",
                        In=ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
        }
    }
}
