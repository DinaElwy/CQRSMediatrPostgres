using CQRSMediatr.DataStore;
using CQRSMediatr.Model;
using CQRSMediatr.PostgresEFCore;
using CQRSMediatr.Queries;
using MediatR;

namespace CQRSMediatr.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductModel>
    {
        private readonly DbHelper _dbHelper;

        public GetProductByIdHandler(DbHelper dbHelper) => _dbHelper = dbHelper;

        public async Task<ProductModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) =>
            await _dbHelper.GetProductById(request.productId);


    }
}
