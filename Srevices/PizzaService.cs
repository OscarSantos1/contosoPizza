using ContosoPizza.Models;

namespace ContosoPizza.Services;

// A static class is a class that CAN NOT be instantiated.
public static class PizzaService
{
  // A Prop is created called Pizzas wich is a List of Pizza objects
  static List<Pizza> Pizzas { get; }
  static int nextId = 3;

  // This is a constructor that initializes the "Pizzas" list 
  static PizzaService()
  {
    Pizzas = new List<Pizza> { 
      new Pizza {Id = 1, Name = "Classic Italian", IsGlutenFree = false},
      new Pizza {Id = 2, Name = "Veggie", IsGlutenFree = true}
    };
  }

  // This is a method that returns the list of Pizza objects (Pizzas). It looks like an arrow function
  public static List<Pizza> GetAll() => Pizzas;
  
  // This is an method that returns a specific item from the "Pizzas" List based on their Id. Also arrow function
                                            //Apparently (Ap.) the type List has a method that returns the fist item found to meet a certain criteria.
  public static Pizza? Get(int id) => Pizzas.FirstOrDefault(pizza => pizza.Id == id);

  // This method takes a new Pizza Object as a parameter, sets an Id for it and Add the object to the Pizzas List.
  public static void Add(Pizza pizza)
  {
    pizza.Id = nextId++;
    Pizzas.Add(pizza);
  }

  // This method Deletes a Pizza object from the Pizzas List if it matches an Id.
  public static void Delete(int id)
  {
    // Calls the Get method
    var pizza = Get(id);
    // If it returns a null (a Pizza was not found with that id)...
    if(pizza is null)
      // ...The methor returns ending the process...
      return;
    // ...But if pizza was not null (a pizza with that id was found) then it removes it from the list using the List method "remove(<object to remove>)"
    Pizzas.Remove(pizza);
  }

  // This method updates a specific Pizza object within Pizzas. (It takes a Pizza object as a parameter)
  public static void Update(Pizza pizza)
  {
    // It uses the List method "FindIndex" to find the index where a certain Pizza object is placed.
                                // It takes the pizza parameter and compares its Id against each of the Pizza object in Pizzas until it finds a match or runs out of Pizza objects...
    var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
    // ... If the method returns a -1 it means it ran out of pizza objects before finding a match
    if(index == -1)
      // Thus we have to return and end the process
      return;
    // If the method does not return a -1 and returns, thus returning a positive integer, then we set the list in that index to the pizza object we took as a parameter.
    Pizzas[index] = pizza;
  }


}