using CQRSMediatr.Model;
using CQRSMediatr.PostgresEFCore;
using MediatR;

namespace CQRSMediatr.Queries
{
    public record GetProductsQuery:IRequest<IEnumerable<ProductModel>>;
}
