
using InventoryManager.Controller;
using InventoryManager.ConsoleInteraction;
using InventoryManager.Manager;
using InventoryManager.Application;

internal class Program
{
    /// <summary>
    /// Main function
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
        ProductRepository productRepository = new ProductRepository();
        UserInteraction userInteraction = new UserInteraction(productRepository);
        ManageInventory inventoryManager = new ManageInventory(productRepository, userInteraction);
        App app = new App(inventoryManager, userInteraction, productRepository);
        app.Run();
    }
}

