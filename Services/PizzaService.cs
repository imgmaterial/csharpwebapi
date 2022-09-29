using dotnetwebapi.Models;

namespace dotnetwebapi.Services;

public static class PizzaService
{
    static List<pizza> pizzas {get;}
    static int nextId = 3;
    static PizzaService()
    {
        pizzas = new List<pizza>
        {
            new pizza {id = 1, Name = "Classic Itallian", IsGlutenFree = false},
            new pizza { id = 2, Name = "Veggie", IsGlutenFree = true }
        };


    }

    public static List<pizza> GetAll() => pizzas;

    public static pizza? Get(int id) => pizzas.FirstOrDefault(p => p.id == id);

    public static void Add(pizza pizza)
    {
        pizza.id = nextId++;
        pizzas.Add(pizza);

    }

    public static void Delete(int id)
    {
        var pizza = Get(id);
        if (pizza is null)
            return;
        
        pizzas.Remove(pizza);

    }

    public static void Update(pizza pizza)
    {
        var index = pizzas.FindIndex(p => p.id == pizza.id);
        if (index == -1)
            return;
        pizzas[index] = pizza;
    }
}