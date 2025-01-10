
using System.Globalization;

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
        InventoryManager inventoryManager = new InventoryManager(productRepository, userInteraction);
        App app = new App(inventoryManager, userInteraction, productRepository);
        app.run();
    }
}

