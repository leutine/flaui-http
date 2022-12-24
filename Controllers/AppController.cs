using flaui_http.Models;
using flaui_http.Services;
using Microsoft.AspNetCore.Mvc;

namespace flaui_http.Controllers;

[ApiController]
[Route("[controller]")]
public class AppController : ControllerBase
{
    private readonly ILogger<AppController> _logger;

    public AppController(ILogger<AppController> logger)
    {
        _logger = logger;
    }

    // GET all action

    // GET by Id action

    [HttpPost]
    public IActionResult Create(App app)
    {
        _logger.LogInformation("Lauching app {AP}", app.ToString());
        AppService.Launch(app);
        return CreatedAtAction(nameof(Create), new { ProcessId = app.ProcessId, Name = app.Name, IsRunning = app.IsRunning }, app);
    }


    // PUT action

    // DELETE action
}