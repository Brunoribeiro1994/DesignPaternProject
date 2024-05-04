using DDD.Infra.Mysql.Model;
using DDD.Infra.Mysql.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Applicattion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<ProductModel> _productRepository;

        public ProductController(IRepository<ProductModel> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<List<ProductModel>> Index()
        {
            return _productRepository.List();
        }
    }
}
