using Wolt_ConsoleApp.Models;

namespace Wolt_ConsoleApp.Data;
internal class AddData
{
    private static readonly DataContext _context = new DataContext();

    public static void AddRestaurantsAndProductsData(DataContext context)
    {
        AddRestaurantsData(context);
        AddProductsData(context);  
    }
    private static void AddRestaurantsData(DataContext context)
    {
        var restaurants = new List<Restaurants>
        {
            new Restaurants { RestaurantName = "Food Haven", RestaurantBalance = 5000.00m, Rating = 4.5, DeliveryAvailable = true },
            new Restaurants { RestaurantName = "Tasty Bites", RestaurantBalance = 3000.00m, Rating = 4.0, DeliveryAvailable = false },
            new Restaurants { RestaurantName = "Sushi World", RestaurantBalance = 7000.00m, Rating = 4.8, DeliveryAvailable = true }
        };
        foreach (var restaurant in restaurants)
        {
            var existingRestaurant = context.Restaurants
                .FirstOrDefault(r => r.RestaurantName.ToLower() == restaurant.RestaurantName.ToLower());

            if (existingRestaurant == null)
            {
                context.Restaurants.Add(restaurant);
            }
        }
        context.SaveChanges();
    }

    private static void AddProductsData(DataContext context)
    {
        var restaurants = context.Restaurants.ToList();
        if (!restaurants.Any())
        {
            Console.WriteLine("No restaurants found. Add restaurants first.");
            return;
        }

        var existingProducts = context.Products.Select(p => p.ProductName.ToLower()).ToHashSet();

        var products = new List<Product>
    {
        new Product { ProductName = "Burger", ProductPrice = 5.99m, IsAvailable = true },
        new Product { ProductName = "Pizza", ProductPrice = 8.99m, IsAvailable = true },
        new Product { ProductName = "Pasta", ProductPrice = 7.49m, IsAvailable = false },
        new Product { ProductName = "Sushi", ProductPrice = 12.99m, IsAvailable = true },
        new Product { ProductName = "Salad", ProductPrice = 4.99m, IsAvailable = true },
        new Product { ProductName = "Fries", ProductPrice = 2.99m, IsAvailable = true },
        new Product { ProductName = "Steak", ProductPrice = 14.99m, IsAvailable = true },
        new Product { ProductName = "Taco", ProductPrice = 3.99m, IsAvailable = true },
        new Product { ProductName = "Soup", ProductPrice = 6.49m, IsAvailable = true }
    };

        // Define how many products each restaurant should have
        var productsPerRestaurant = new List<int> { 5, 3, 2 };

        int productIndex = 0; // To track which product we're assigning
        for (int i = 0; i < restaurants.Count; i++)
        {
            var restaurant = restaurants[i];
            int productCountForThisRestaurant = productsPerRestaurant[i]; // Number of products for this restaurant

            for (int j = 0; j < productCountForThisRestaurant && productIndex < products.Count; j++)
            {
                var product = products[productIndex];
                if (!existingProducts.Contains(product.ProductName.ToLower())) // Ensure product is not duplicated
                {
                    var newProduct = new Product
                    {
                        ProductName = product.ProductName,
                        ProductPrice = product.ProductPrice,
                        IsAvailable = product.IsAvailable,
                        RestaurantsId = restaurant.Id
                    };

                    context.Products.Add(newProduct);
                }

                productIndex++; // Move to the next product
            }
        }

        context.SaveChanges();
    }

}
