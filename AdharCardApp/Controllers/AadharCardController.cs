// Controllers/AadharCardController.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AadharCardController : ControllerBase
{
    private readonly IAadharCardService _AadharCardService;

    public AadharCardController(IAadharCardService AadharCardService)
    {
        _AadharCardService = AadharCardService;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_AadharCardService.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var card = _AadharCardService.GetById(id);
        return card != null ? Ok(card) : NotFound();
    }

    [HttpPost]
    public IActionResult Add([FromBody] AadharCard AadharCard)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            _AadharCardService.Add(AadharCard);
            return CreatedAtAction(nameof(GetById), new { id = AadharCard.Id }, AadharCard);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] AadharCard AadharCard)
    {
        try
        {
            AadharCard.Id = id;
            _AadharCardService.Update(AadharCard);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        _AadharCardService.Delete(id);
        return NoContent();
    }

    [HttpGet("filter")]
    public IActionResult Filter([FromQuery] string name, [FromQuery] string state, [FromQuery] string city)
    {
        var result = _AadharCardService.FilterBy(name, state, city);
        return Ok(result);
    }
}
