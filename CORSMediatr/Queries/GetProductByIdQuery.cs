using MediatR;
using CQRSMediatr.PostgresEFCore;
using CQRSMediatr.Model;

namespace CQRSMediatr.Queries
{
    public record GetProductByIdQuery(int productId) : IRequest<ProductModel>;
}
