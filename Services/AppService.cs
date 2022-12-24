using flaui_http.Models;
using FlaUI.UIA3;
using FlaUI.Core.Conditions;
using FlaUI.Core.AutomationElements;
using FlaUI.Core;
using FlaUI.Core.Capturing;

namespace flaui_http.Services;


public static class AppService
{
    // static List<Pizza> Pizzas { get; }
    // static int nextId = 3;
    private static UIA3Automation automation;
    private static Application? application;
    // private static App app;
    // private static Window window;
    private static ConditionFactory cf;
    static AppService()
    {

        automation = new UIA3Automation();
        cf = new ConditionFactory(new UIA3PropertyLibrary());

        // Pizzas = new List<Pizza>
        // {
        //     new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
        //     new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
        // };
    }

    // public static List<Pizza> GetAll() => Pizzas;

    // public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    // public static void Add(Pizza pizza)
    // {
    //     pizza.Id = nextId++;
    //     Pizzas.Add(pizza);
    // }

    // public static void Delete(int id)
    // {
    //     var pizza = Get(id);
    //     if(pizza is null)
    //         return;

    //     Pizzas.Remove(pizza);
    // }

    // public static void Update(Pizza pizza)
    // {
    //     var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
    //     if(index == -1)
    //         return;

    //     Pizzas[index] = pizza;
    // }

    public static void Launch(App app)
    {
        application = Application.Launch(app.Path);
        Window window = application.GetMainWindow(automation);

        app.ProcessId = application.ProcessId;
        app.IsRunning = true;
        app.Name = window.Title;
    }

}