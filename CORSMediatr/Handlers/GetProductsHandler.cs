using CQRSMediatr.DataStore;
using CQRSMediatr.Model;
using CQRSMediatr.PostgresEFCore;
using CQRSMediatr.Queries;
using MediatR;

namespace CQRSMediatr.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductModel>>
    {
        private readonly DbHelper _dbHelper;

        public GetProductsHandler(DbHelper dbHelper) => _dbHelper = dbHelper;

        public async Task<IEnumerable<ProductModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _dbHelper.GetAllProducts();
        }
    }
}
