
using ConsoleApp1.Repository;

ProductRepository productRepository = new ProductRepository();
var product = productRepository.Find(Guid.Parse("11646477-7125-4a47-964e-bb408de11b25"));


productRepository.Delete(product.Id);
Console.ReadLine();
