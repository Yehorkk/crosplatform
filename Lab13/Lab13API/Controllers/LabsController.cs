using App.Models;
using App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Lab5CL;
using Microsoft.AspNetCore.Components.Forms;
using Lab13API.Models;

namespace App.Controllers;

[ApiController]
[Route("api/labs")]
public class LabsController : ControllerBase
{
    private readonly Lab1 _lab1;
    private readonly Lab2 _lab2;
    private readonly Lab3 _lab3;

    public LabsController()
    {
        _lab1 = new Lab1();
        _lab2 = new Lab2();
        _lab3 = new Lab3();
    }

    [HttpPost("lab1")]
    [Authorize]
    public ActionResult Lab1([FromBody] Lab requestModel)
    {
        try
        {
            string result = _lab1.Run(requestModel.input, requestModel.output);
            return Ok(new { result });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    [HttpPost("lab2")]
    [Authorize]
    public ActionResult Lab2([FromBody] Lab requestModel)
    {
        try
        {
            string result = _lab2.Run(requestModel.input, requestModel.output);
            return Ok(new { result });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    [HttpPost("lab3")]
    [Authorize]
    public ActionResult Lab3([FromBody] Lab requestModel)
    {
        try
        {
            string result = _lab3.Run(requestModel.input, requestModel.output);
            return Ok(new { result });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}
