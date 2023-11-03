using lexicon_vendingmachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace lexicon_vendingmachine
{
    public class VendingMachineService:IVending
    {
        public List<Product> Products { get; }

        public VendingMachineService() {
            Products = ThordsHelper.JsonToList(new ProductConverter());
            Console.WriteLine(Products[0].GetType());
        }

        public string Details(int productId) {
            throw new NotImplementedException();
        }

        public void InsertMoney(decimal amount) {
            throw new NotImplementedException();
        }

        public Product Purchase(int id, int money) {
            Product product = new Drink("Cola", Volume.cl50);
            return product;
        }

        public List<string> ShowAll() {
            //List<string> list = ListHelper.indexStringList();
            throw new NotImplementedException();
        }

        public Dictionary<int, int> EndTransaction() {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// This is a coverter class to be able to deserialize polymorphic objects into the right type. I finally succeeded :D
    /// </summary>
    public class ProductConverter:JsonConverter<Product>
    {
        public override Product Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            using(JsonDocument doc = JsonDocument.ParseValue(ref reader)) {
                var root = doc.RootElement;
                if(root.TryGetProperty("Type", out var typeProperty)) {
                    string productType = typeProperty.GetString();
                    if(productType == "Drink") {
                        return JsonSerializer.Deserialize<Drink>(root.GetRawText(), options);
                    }
                    // Add additional cases for other product types if needed.
                }
            }

            // Default to returning a base Product if "Type" is not recognized.
            return JsonSerializer.Deserialize<Product>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, Product value, JsonSerializerOptions options) {
            // Implement serialization logic if needed.
        }
    }
}
