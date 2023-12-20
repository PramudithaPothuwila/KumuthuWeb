using KumuthuWeb.Data;
using Microsoft.AspNetCore.Mvc;

namespace KumuthuWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    private readonly ILogger<ApiController> _logger;
    private readonly GlobalCounter _globalCounter;

    public ApiController(GlobalCounter globalCounter, ILogger<ApiController> logger)
    {
        _logger = logger;
        _globalCounter = globalCounter ?? throw new ArgumentNullException(nameof(globalCounter));
    }

    [HttpPut("add")]
    public IActionResult Increment()
    {
        try
        {
            _globalCounter.Increment();
            return Ok(new { CounterValue = _globalCounter.Counter });
        }
        catch (Exception ex)
        {
            _logger.LogError(new EventId(), ex, ex.Message);
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpPut("subtract")]
    public IActionResult Decrement()
    {
        try
        {
            _globalCounter.Decrement();
            return Ok(new { CounterValue = _globalCounter.Counter });
        }
        catch (Exception ex)
        {
            _logger.LogError(new EventId(), ex, ex.Message);
            return StatusCode(500, "Internal Server Error");
        }
    }
}