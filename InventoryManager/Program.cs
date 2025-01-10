
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        ProductRepository productRepository = new ProductRepository();
        UserInteraction userInteraction = new UserInteraction(productRepository);
        InventoryManager inventoryManager = new InventoryManager(productRepository, userInteraction);
        App app = new App(inventoryManager, userInteraction, productRepository);
        app.run();
    }
}

