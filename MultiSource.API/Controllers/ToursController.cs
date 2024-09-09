using Microsoft.AspNetCore.Mvc;
using MultiSource.Domain.DTOs;
using MultiSource.Domain.Services;

namespace MultiSource.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ToursController : ControllerBase
{
    private readonly ITourService _tourService;

    public ToursController(ITourService tourService)
    {
        _tourService = tourService;
    }

    [HttpGet]
    public async Task<IActionResult> Search([FromQuery] TourSearchRequestDto request)
    {
        return Ok(await _tourService.GetFilteredTours(request));
    }
}
