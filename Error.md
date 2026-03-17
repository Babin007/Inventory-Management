-Swagger error on application run-> program.cs
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        // This makes Swagger available at the root (/) 
        // instead of (/swagger)
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty; 
    });
}
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
-Globalization Invariant Mode is not supported
The error "Globalization Invariant Mode is not supported" is happening because your project is running in a restricted culture mode (common in some Docker containers or Linux-based environments), but the SQL Server driver (Microsoft.Data.SqlClient) requires full globalization support to handle things like sorting and formatting.
You can fix this by disabling "Invariant Mode" in your project settings.
1. Update your Project File
Open your ECommerce.Api.csproj file and find the <InvariantGlobalization> tag. Change it to false:

<PropertyGroup>
  ...
  <InvariantGlobalization>false</InvariantGlobalization>
</PropertyGroup>

2. Alternative: Environment Variable
If you are working in a Codespace or a terminal environment where you can't easily change the .csproj, run this command in your terminal before updating:
bash
export DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=0

