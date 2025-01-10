﻿/// <summary>
/// UserInteraction interface handle all the user interaction
/// </summary>
public interface IUserInteraction
{
    public void displayOptions();
    public void displayEditOptions();
    public void displayAllProducts(List<Product> allProducts);
    public Product getNewProductDetail();
    
    public string GetAndValidateStringInput(string message);
    public int GetAndValidateIntInput(string message);

}

