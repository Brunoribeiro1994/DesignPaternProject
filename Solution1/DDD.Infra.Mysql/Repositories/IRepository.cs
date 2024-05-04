
namespace DDD.Infra.Mysql.Repositories;

public interface IRepository<T>
{
    public List<T> List();
    public T? GetProduct(Guid id);
    public void Create(T data);
    public void Update(T data);
    public void Delete(T data);
}
