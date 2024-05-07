using DDD.Infra.Mysql.Model;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.Mysql.Repositories.Product;

public class ProductRepository : IRepository<ProductModel>
{
    protected readonly MysqlServerContext _context;

    public ProductRepository(MysqlServerContext context)
    {
        _context = context;
    }

    public List<ProductModel> List()
    {
        return _context.Set<ProductModel>().ToList();
    }

    public ProductModel? GetProduct(Guid id)
    {

        var product = _context.Set<ProductModel>()
            .Find(id);

        return product;
    }

    public void Create(ProductModel data)
    {
        try
        {
            _context.Set<ProductModel>().Add(data);
            _context.SaveChanges();
        } catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Update(ProductModel data)
    {
        try
        {
            _context.Products.Update(data);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void Delete(ProductModel data)
    {
        _context.Set<ProductModel>().Remove(data);
        _context.SaveChanges();
    }
}
