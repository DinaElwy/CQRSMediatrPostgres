using CQRSMediatr.Commands;
using CQRSMediatr.DataStore;
using CQRSMediatr.Model;
using CQRSMediatr.PostgresEFCore;
using MediatR;

namespace CQRSMediatr.Handlers
{
    public class SaveProductHandler : IRequestHandler<SaveProductCommand, ProductModel>
    {
        private readonly DbHelper _dbHelper;

        public SaveProductHandler(DbHelper dbHelber)
        {
            _dbHelper = dbHelber;
        }

        public async Task<ProductModel> Handle(SaveProductCommand request, CancellationToken cancellationToken)
        {
            await _dbHelper.SaveProduct(request.product);
            return request.product;
        }
    }
}
