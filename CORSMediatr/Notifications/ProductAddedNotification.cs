using CQRSMediatr.Model;
using CQRSMediatr.PostgresEFCore;
using MediatR;

namespace CQRSMediatr.Notifications
{
	public record ProductAddedNotification(ProductModel Product) : INotification;
}
