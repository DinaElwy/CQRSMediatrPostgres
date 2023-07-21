using CQRSMediatr.Model;
using CQRSMediatr.PostgresEFCore;
using MediatR;

namespace CQRSMediatr.Commands
{
    public record SaveProductCommand(ProductModel product) : IRequest<ProductModel>;

}
