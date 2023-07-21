using CQRSMediatr.Model;
using CQRSMediatr.PostgresEFCore;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatr.DataStore
{
    public class DbHelper
    {
        private EF_DataContext _dataContext;
        
        public DbHelper(EF_DataContext dataContext) {  _dataContext = dataContext; }
        public async Task<ProductModel> SaveProduct(ProductModel productModel)
        {
            PostgresEFCore.Product product = new PostgresEFCore.Product();
            if (productModel.ProductId > 0)
            {
                product = _dataContext.Products.FirstOrDefault(o => o.ProductId == productModel.ProductId);
                if (product != null)
                {
                    product.Brand = productModel.Brand;
                    product.Price = productModel.Price;
                    product.Size = productModel.Size;
                }
                else
                {
                    product = new PostgresEFCore.Product();
                    product.Brand = productModel.Brand;
                    product.Price = productModel.Price;
                    product.Name = productModel.Name;
                    product.Size = productModel.Size;
                    _dataContext.Products.Add(product);
                }
                _dataContext.SaveChanges();
            }

            return await Task.FromResult(productModel);
        }

        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            List<ProductModel> result = new List<ProductModel>();
            var products = _dataContext.Products.ToList();
            products.ForEach(row =>
            {
                result.Add(new ProductModel()
                {
                    Name = row.Name,
                    ProductId = row.ProductId,
                    Brand = row.Brand,
                    Price = row.Price,
                    Size = row.Size
                });
            }
            );
            return await Task.FromResult(result);
        }

        public async Task<ProductModel> GetProductById(int productId)
        {
            ProductModel result = new ProductModel();
            var product = _dataContext.Products.Single(p => p.ProductId == productId);
            result = new ProductModel()
            {
                Name = product.Name,
                ProductId = product.ProductId,
                Brand = product.Brand,
                Price = product.Price,
                Size = product.Size
            };

            return await Task.FromResult(result);
        }

        public async Task EventOccured(ProductModel product, string evt)
        {
            _dataContext.Products.Single(p => p.ProductId == product.ProductId).Name = $"{product.Name} evt: {evt}";
            await Task.CompletedTask;
        }
    }
}
