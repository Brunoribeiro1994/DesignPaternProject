using DDD.Infra.Mysql.Model;
using DDD.Infra.Mysql.Repositories;
using Microsoft.AspNetCore.Mvc;
using Sistema.Vendas.Domain.ProductContext;
using System.Xml.Linq;

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

        [HttpPost]
        public ActionResult Create([FromBody] ProductModel model)
        {
            var product = new ProductContext(model.Name, model.Description, model.Quantity, model.Price, model.LinkPhoto);
            var data = new ProductModel(product.Id, product.Name, product.Description, product.Quantity, product.Price, product.LinkPhoto, product.CreatedAt);
            _productRepository.Create(data);

            return Ok("Produto atualizado com sucesso");
        }

        [HttpPut]
        public ActionResult Put([FromBody] ProductModel model)
        {
            var product = new ProductContext(model.Name, model.Description, model.Quantity, model.Price, model.LinkPhoto);
            var data = new ProductModel(product.Id, product.Name, product.Description, product.Quantity, product.Price, product.LinkPhoto, product.CreatedAt);
            try
            {
                if (data == null)
                {
                    return NotFound();
                }
                _productRepository.Update(data);
                return Ok("Produto atualizado com sucesso");

            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpDelete]
        public ActionResult Delete([FromBody] ProductModel model)
        {
            var product = new ProductContext(model.Name, model.Description, model.Quantity, model.Price, model.LinkPhoto);
            var data = new ProductModel(product.Id, product.Name, product.Description, product.Quantity, product.Price, product.LinkPhoto, product.CreatedAt);
            try
            {
                if (data == null)
                {
                    return NotFound();
                }
                _productRepository.Delete(data);
                return Ok("Produto Deletado com sucesso");

            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
