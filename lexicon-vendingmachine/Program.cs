
namespace lexicon_vendingmachine
{
    internal class Program
    {
        static void Main(string[] args) {
            VendingMachineService service = new VendingMachineService();
            List<Product> products = new List<Product>();
            foreach(Product product in service.Products) {
                products.Add(product.Clone());
            }

            Console.WriteLine(ThordsHelper.indexList(products));
        }
    }
}