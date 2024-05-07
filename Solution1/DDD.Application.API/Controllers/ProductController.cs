using DDD.Infra.Mysql.Model;
using DDD.Infra.Mysql.Repositories;
using Microsoft.AspNetCore.Mvc;
using Sistema.Vendas.Domain.ProductContext;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        [HttpGet("{id}")]
        public ActionResult<ProductModel?> Index(Guid id)
        {
            return _productRepository.GetProduct(id);
        }

        [HttpPost]
        public ActionResult Create([FromBody] ProductModel model)
        {
            var product = new ProductContext(model.Name, model.Description, model.Quantity, model.Price, model.LinkPhoto);
            var data = new ProductModel(product.Id, product.Name, product.Description, product.Quantity, product.Price, product.LinkPhoto, product.CreatedAt);
            _productRepository.Create(data);

            return Ok("Produto Criado com sucesso");
        }

        [HttpPut]
        public ActionResult Put([FromBody] ProductModel model)
        {
            try
            {
                var productUpdate = ConverteModelToEntity(model);
                productUpdate.Update(model.Name, model.Description, model.Quantity, model.Price, model.LinkPhoto);

                var data = new ProductModel(
                    model.Id,
                    model.Name,
                    model.Description,
                    model.Quantity,
                    model.Price,
                    model.LinkPhoto,
                    model.CreatedAt);

                if (data == null)
                    return NotFound();

                _productRepository.Update(data);
                return Ok("Produto atualizado com sucesso");
            } catch (Exception ex)
            {
                return NotFound(); 
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] ProductModel model)
        {
            var product = _productRepository.GetProduct(model.Id);
            if (product == null)
                return NotFound();

            _productRepository.Delete(product);
            return Ok("Produto Deletado com sucesso");
        }

        private ProductContext ConverteModelToEntity(ProductModel productModel)
        {
            return new ProductContext(productModel.Name, productModel.Description, productModel.Quantity, productModel.Price, productModel.LinkPhoto);
        }
    }
}
