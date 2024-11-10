using Microsoft.AspNetCore.Mvc;
using MyProject.Application.HomeChores;
using MyProject.Application.HomeChores.Dto;

namespace MyProject.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeChoreController : ControllerBase
{
    private readonly IHomeChoreService _homeChoreService;

    public HomeChoreController(IHomeChoreService homeChoreService)
    {
        _homeChoreService = homeChoreService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var chores = await _homeChoreService.GetAll(cancellationToken);
        return Ok(chores);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var chore = await _homeChoreService.GetById(id, cancellationToken);
        if (chore == null)
        {
            return NotFound();
        }
        return Ok(chore);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] HomeChoreCreateDto createHomeChoreDto, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdChore = await _homeChoreService.Create(createHomeChoreDto, cancellationToken);
        return !createdChore.IsSuccessful ? BadRequest(createdChore.ErrorMessage) : Ok();
    }
}
