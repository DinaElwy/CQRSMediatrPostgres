using CQRSMediatr.Model;
using CQRSMediatr.PostgresEFCore;
using MediatR;

namespace CQRSMediatr.Commands
{
    /// <summary>
    /// Add or Update Product
    /// </summary>
    /// <param name="product"></param>
    public record SaveProductCommand(ProductModel product) : IRequest<ProductModel>;

}
