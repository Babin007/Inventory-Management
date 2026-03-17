using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

[ApiController]
[Route("api/health")]
public class HealthController : ControllerBase
{
    private readonly IConfiguration _config;

    public HealthController(IConfiguration config)
    {
        _config = config;
    }

    [HttpGet("db-ado")]
    public async Task<IActionResult> CheckDbWithAdo()
    {
        try
        {
            var connectionString = _config.GetConnectionString("Sql");

            using var conn = new SqlConnection(connectionString);
            await conn.OpenAsync();

            return Ok(new { databaseConnection = true });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                databaseConnection = false,
                error = ex.Message
            });
        }
    }
}