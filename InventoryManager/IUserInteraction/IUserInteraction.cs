public interface IUserInteraction
{
    public void displayOptions();
    public void displayEditOptions();
    public void displayAllProducts(List<Product> allProducts);
    public Product getNewProductDetail();
    public int getAndValidateID();

}

