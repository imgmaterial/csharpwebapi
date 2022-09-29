using dotnetwebapi.Models;
using dotnetwebapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnetwebapi.Controllers;

[ApiController]
[Route("[controller]")]
public class pizzaController : ControllerBase
{
    public pizzaController()
    {

    }

    [HttpGet]
    public ActionResult<List<pizza>> GetAll() =>
        PizzaService.GetAll();
    
    [HttpGet("{id}")]
    public ActionResult<pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);

        if (pizza == null)
            return NotFound();
        
        return pizza;
    }
    [HttpPost]
    public IActionResult Create(pizza pizza)
    {
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Create),new {id = pizza.id}, pizza);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, pizza pizza)
    {
        if (id != pizza.id)
            return BadRequest();
        var existingPizza = PizzaService.Get(id);
        if (existingPizza is null)
            return NotFound();
        PizzaService.Update(pizza);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = PizzaService.Get(id);
        if (pizza is null)
            return NotFound();
        
        PizzaService.Delete(id);
        return NoContent();
    }


}