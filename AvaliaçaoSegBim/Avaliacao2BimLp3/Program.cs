using Microsoft.Data.Sqlite;
using Avaliacao3BimLp3.Database;
using Avaliacao3BimLp3.Models;
using Avaliacao3BimLp3.Repositories;

var databaseConfig = new DatabaseConfig();
var DatabaseSetup = new DatabaseSetup(databaseConfig);

var productRepository = new ProductRepository(databaseConfig);

var modelName = args[0];
var modelAction = args[1];

if(modelName == "Product")
{
    if(modelAction == "New")
    {
        var id = Convert.ToInt32(args[2]);
        var name = args[3];
        var price = Convert.ToDouble(args[4]);
        var active = Convert.ToBoolean(args[5]);

        var product = new Product(id, name, price, active);
        if(productRepository.ExistsById(id))
        {
            Console.WriteLine($"Produto com Id {id} já existe");
        }else
        {
            productRepository.Save(product);
            Console.WriteLine($"Produto {name} cadastrado com sucesso");
        }
    }

    if(modelAction == "Delete")
    {
        var id = Convert.ToInt32(args[2]);

        if(productRepository.ExistsById(id))
        {
            productRepository.Delete(id);
            Console.WriteLine($"Produto {id} removido com sucesso");
        }else
        {
            Console.WriteLine($"Produto {id} não encontrado!");
        }
    }

    if(modelAction == "Enable")
    {
        var id = Convert.ToInt32(args[2]);

        if(productRepository.ExistsById(id))
        {
            productRepository.Enable(id);
            Console.WriteLine($"Produto {id} habilitado com sucesso");
        }else
        {
            Console.WriteLine($"Produto {id} não encontrado!");
        }
    }

    if(modelAction == "Disable")
    {
        var id = Convert.ToInt32(args[2]);

        if(productRepository.ExistsById(id))
        {
            productRepository.Disable(id);
            Console.WriteLine($"Produto {id} desabilitado com sucesso");
        }else
        {
            Console.WriteLine($"Produto {id} não encontrado!");
        }
    }

    if(modelAction == "List")
    {
        if(productRepository.GetAll().Any())
        {
            Console.WriteLine("Product List");
            foreach (var product in productRepository.GetAll())
            {
                Console.WriteLine($"{product.Id}, {product.Name}, {product.Price}, {product.Active}");
            } 
        }else
        {
            Console.WriteLine("Nenhum produto cadastrado");
        } 
    }

    if(modelAction == "PriceBetween")
    {
        var initialPrice = Convert.ToDouble(args[2]);
        var endPrice = Convert.ToDouble(args[3]);

        if(productRepository.GetAllWithPriceBetween(initialPrice, endPrice).Any())
        {
            Console.WriteLine("Product Between");
            foreach (var product in productRepository.GetAllWithPriceBetween(initialPrice, endPrice))
            {
                Console.WriteLine($"{product.Id}, {product.Name}, {product.Price}, {product.Active}");
            }
        }else
        {
            Console.WriteLine($"Nenhum produto encontrado dentro do intervalo de preço R${initialPrice} e R${endPrice}");
        }
    }

    if(modelAction == "PriceHigherThan")
    {
        var price = Convert.ToDouble(args[2]);

        if(productRepository.GetAllWithPriceHigherThan(price).Any())
        {
            Console.WriteLine("Product Higher Than");
            foreach (var product in productRepository.GetAllWithPriceHigherThan(price))
            {
                Console.WriteLine($"{product.Id}, {product.Name}, {product.Price}, {product.Active}");
            }
        }else
        {
            Console.WriteLine($"Nenhum produto encontrado com preço maior que R${price}");
        }
    }

    if(modelAction == "PriceLowerThan")
    {
        var price = Convert.ToDouble(args[2]);

        if(productRepository.GetAllWithPriceLowerThan(price).Any())
        {
            Console.WriteLine("Product Lower Than");
            foreach (var product in productRepository.GetAllWithPriceLowerThan(price))
            {
                Console.WriteLine($"{product.Id}, {product.Name}, {product.Price}, {product.Active}");
            }
        }else
        {
            Console.WriteLine($"Nenhum produto encontrado com preço menor que R${price}");
        }
    }

    if(modelAction == "AveragePrice")
    {
        if(productRepository.GetAll().Any())
        {
            Console.WriteLine($"O preço médio dos produtos é: R${productRepository.GetAveragePrice()}");
        }else
        {
            Console.WriteLine("Nenhum produto cadastrado");
        }
    }
}