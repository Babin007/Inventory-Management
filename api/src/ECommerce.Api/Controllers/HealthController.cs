using Microsoft.AspNetCore.Mvc;
using ECommerce.Data;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/health")]
public class HealthController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public HealthController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("db-ado")]
    public async Task<IActionResult> CheckDbWithAdo()
    {
        try
        {
            var canConnect = await _dbContext.Database.CanConnectAsync();

            if (!canConnect)
            {
                return StatusCode(500, new
                {
                    databaseConnection = false,
                    error = "Database connection failed"
                });
            }

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