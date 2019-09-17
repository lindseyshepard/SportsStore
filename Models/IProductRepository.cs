using System.Linq;
namespace SportsStore.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; } //read only because does not have set;
        //IQueryable works with collections from LINQ namespace
        //interface for dependency injection
    }
}