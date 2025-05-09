using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices;

[ApiController]
[Route("[controller]")]
public class ControleController : ControllerBase
{
    [HttpGet("DesligarPC")]
    public IActionResult Desligar()
    {
        Process.Start("shutdown", "/s /t 0");
        return Ok("Desligando o PC...");
    }
}