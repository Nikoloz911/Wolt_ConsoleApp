using Wolt_ConsoleApp.Models;

namespace Wolt_ConsoleApp.Data;
internal class AddData
{
    public static readonly DataContext _context = new DataContext();

    public static void AddRestaurantsAndProductsData(DataContext context)
    {
        AddRestaurantsData(context);
        AddProductsData(context);
    }
    public static void AddRestaurantsData(DataContext context)
    {
        var restaurants = new List<Restaurants>
        {
            new Restaurants { RestaurantName = "Megrelebi", RestaurantBalance = 15000.00m, Rating = 9.8, DeliveryAvailable = true },
            new Restaurants { RestaurantName = "NUR Cofee Shop", RestaurantBalance = 9000.00m, Rating = 9.8, DeliveryAvailable = true },
            new Restaurants { RestaurantName = "Merdini", RestaurantBalance = 4000.00m, Rating = 9.6, DeliveryAvailable = true },
            new Restaurants { RestaurantName = "SKA Greenhill", RestaurantBalance = 6000.00m, Rating = 9.6, DeliveryAvailable = false },
            new Restaurants { RestaurantName = "Marge", RestaurantBalance = 16000.00m, Rating = 8.6, DeliveryAvailable = true },
            new Restaurants { RestaurantName = "Dunkin", RestaurantBalance = 18000.00m, Rating = 9.2, DeliveryAvailable = true },
            new Restaurants { RestaurantName = "McDonald's", RestaurantBalance = 25000.00m, Rating = 8.8, DeliveryAvailable = true },
            new Restaurants { RestaurantName = "Domino's Pizza", RestaurantBalance = 20000.00m, Rating = 8.8, DeliveryAvailable = true },
            new Restaurants { RestaurantName = "Rachvelebi", RestaurantBalance = 1000.00m, Rating = 9.4, DeliveryAvailable = false },
            new Restaurants { RestaurantName = "KFC", RestaurantBalance = 16000.00m, Rating = 8.8, DeliveryAvailable = true },
            new Restaurants { RestaurantName = "Khinkali House", RestaurantBalance = 11000.00m, Rating = 9.0, DeliveryAvailable = true },
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

    public static void AddProductsData(DataContext context)
    {
        var restaurants = context.Restaurants.ToList();
        var existingProducts = context.Products.Select(p => p.ProductName.ToLower()).ToHashSet();
        if (restaurants.Count == 0)
        {
            Console.WriteLine("No restaurants found in the database. Products cannot be added.");
            return;
        }
        var products = new List<Product>
    {
            // Megrelebi Products
        new Product { ProductName = "Gomi", ProductQuantity = 15.00m, ProductPrice = 8.99m, IsAvailable = true },
        new Product { ProductName = "Baze", ProductQuantity = 10.00m, ProductPrice = 12.00m, IsAvailable = true },
        new Product { ProductName = "Xarcho", ProductQuantity = 6.00m, ProductPrice = 22.00m, IsAvailable = false },
        new Product { ProductName = "Elarji", ProductQuantity = 5.00m, ProductPrice = 22.00m, IsAvailable = true },
        new Product { ProductName = "Sawebeli", ProductQuantity = 0.00m, ProductPrice = 8.00m, IsAvailable = true },

        // NUR Cofee Shop Products
        new Product { ProductName = "Filter Coffee", ProductQuantity = 10.00m, ProductPrice = 9.00m, IsAvailable = true },
        new Product { ProductName = "Expresso", ProductQuantity = 14.00m, ProductPrice = 12.00m, IsAvailable = true },
        new Product { ProductName = "Americano", ProductQuantity = 10.00m, ProductPrice = 9.00m, IsAvailable = false },
        new Product { ProductName = "Cappuccino", ProductQuantity = 9.00m, ProductPrice = 12.00m, IsAvailable = true },
        new Product { ProductName = "Apple Pie", ProductQuantity = 7.00m, ProductPrice = 6.00m, IsAvailable = true },
        new Product { ProductName = "Latte", ProductQuantity = 4.00m, ProductPrice = 15.00m, IsAvailable = true },
        new Product { ProductName = "Filter Coffee 2", ProductQuantity = 6.00m, ProductPrice = 9.00m, IsAvailable = true },

        // Merdini Products
        new Product { ProductName = "Lobiani", ProductQuantity = 40.00m, ProductPrice = 15.00m, IsAvailable = true },
        new Product { ProductName = "Lobiani Lorit", ProductQuantity = 22.00m, ProductPrice = 18.00m, IsAvailable = true },
        new Product { ProductName = "Lobiani Bekonit", ProductQuantity = 18.00m, ProductPrice = 15.00m, IsAvailable = false },
        new Product { ProductName = "Xachapuri", ProductQuantity = 12.00m, ProductPrice = 25.00m, IsAvailable = true },
        new Product { ProductName = "Pepsi", ProductQuantity = 0.00m, ProductPrice = 3.50m, IsAvailable = true },

        // SKA Greenhill Products
        new Product { ProductName = "Cookie", ProductQuantity = 18.00m, ProductPrice = 4.00m, IsAvailable = true },
        new Product { ProductName = "Baunti", ProductQuantity = 9.00m, ProductPrice = 7.00m, IsAvailable = true },
        new Product { ProductName = "Expresso", ProductQuantity = 6.00m, ProductPrice = 6.00m, IsAvailable = true },
        new Product { ProductName = "Americano", ProductQuantity = 4.00m, ProductPrice = 7.00m, IsAvailable = true },
        new Product { ProductName = "Sandwich", ProductQuantity = 0.00m, ProductPrice = 5.00m, IsAvailable = false },
        // Marge Products
        new Product { ProductName = "Shaurma", ProductQuantity = 1.00m, ProductPrice = 13.00m, IsAvailable = true },
        new Product { ProductName = "Fries", ProductQuantity = 14.00m, ProductPrice = 5.00m, IsAvailable = true },
        new Product { ProductName = "Coca-Cola", ProductQuantity = 10.00m, ProductPrice = 2.00m, IsAvailable = true },
        new Product { ProductName = "Water", ProductQuantity = 18.00m, ProductPrice = 1.00m, IsAvailable = true },
        new Product { ProductName = "Fanta", ProductQuantity = 11.00m, ProductPrice = 2.00m, IsAvailable = false },

        // Dunkin Products
        new Product { ProductName = "Donati", ProductQuantity = 40.00m, ProductPrice = 2.00m, IsAvailable = true },
        new Product { ProductName = "Raf Coffee", ProductQuantity = 14.00m, ProductPrice = 10.99m, IsAvailable = true },
        new Product { ProductName = "Late", ProductQuantity = 18.00m, ProductPrice = 7.90m, IsAvailable = true },
        new Product { ProductName = "tea", ProductQuantity = 10.00m, ProductPrice = 5.99m, IsAvailable = false },
        // McDonald's Products
        new Product { ProductName = "Double cheeseburger Mcmenu", ProductQuantity = 4.00m, ProductPrice = 13.99m, IsAvailable = true },
        new Product { ProductName = "Big Mcmenu", ProductQuantity = 8.00m, ProductPrice = 18.75m, IsAvailable = true },
        new Product { ProductName = "Chiken Nugets", ProductQuantity = 90.00m, ProductPrice = 9.85m, IsAvailable = true },
        new Product { ProductName = "Double cheeseburger", ProductQuantity = 80.00m, ProductPrice = 9.45m, IsAvailable = true },
        new Product { ProductName = "Royal Set", ProductQuantity = 7.00m, ProductPrice = 50.45m, IsAvailable = true },
        new Product { ProductName = "Happy Meal", ProductQuantity = 5.00m, ProductPrice = 11.65m, IsAvailable = true },
        new Product { ProductName = "Fries", ProductQuantity = 40.00m, ProductPrice = 5.95m, IsAvailable = true },
        new Product { ProductName = "Coca-Cola", ProductQuantity = 30.00m, ProductPrice = 4.25m, IsAvailable = true },
        new Product { ProductName = "Sprite", ProductQuantity = 19.00m, ProductPrice = 4.25m, IsAvailable = false },

        // Domino's Pizza Products
        new Product { ProductName = "Medium Pizza", ProductQuantity = 2.00m, ProductPrice = 28.49m, IsAvailable = true },
        new Product { ProductName = "Large Pizza", ProductQuantity = 8.00m, ProductPrice = 39.99m, IsAvailable = true },
        new Product { ProductName = "Peperon Pizza", ProductQuantity = 6.00m, ProductPrice = 13.10m, IsAvailable = true },
        new Product { ProductName = "Margarita", ProductQuantity = 12.00m, ProductPrice = 13.52m, IsAvailable = true },
        // Rachvelebi Products
        new Product { ProductName = "Lobiani", ProductQuantity = 13.00m, ProductPrice = 18.00m, IsAvailable = true },
        new Product { ProductName = "Lobiani fena-fena", ProductQuantity = 4.00m, ProductPrice = 22.00m, IsAvailable = true },
        new Product { ProductName = "Rachuli Yveliani", ProductQuantity = 16.00m, ProductPrice = 27.90m, IsAvailable = true },

        // KFC Products
        new Product { ProductName = "Basket", ProductQuantity = 10.00m, ProductPrice = 19.85m, IsAvailable = true },
        new Product { ProductName = "Basket 2", ProductQuantity = 20.00m, ProductPrice = 35.80m, IsAvailable = true },
        new Product { ProductName = "Solo Basket", ProductQuantity = 9.00m, ProductPrice = 8.00m, IsAvailable = false },
        new Product { ProductName = "Nacho cheeseburger", ProductQuantity = 11.00m, ProductPrice = 15.80m, IsAvailable = true },
        // Khinkali House Products
        new Product { ProductName = "Xinkali 10", ProductQuantity = 100.00m, ProductPrice = 20.00m, IsAvailable = true },
        new Product { ProductName = "Xinkali 20", ProductQuantity = 150.00m, ProductPrice = 38.00m, IsAvailable = true },
        
    };
        // Define how many products each restaurant should have
        var productsPerRestaurant = new List<int> { 5, 7, 5, 5, 5, 4, 9, 4, 3, 4, 2, };
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
                        ProductQuantity = product.ProductQuantity,
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
