using CQRSMediatr.DataStore;
using CQRSMediatr.Model;
using CQRSMediatr.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSMediatr.Handlers
{
    public class EmailHandler : INotificationHandler<ProductAddedNotification>
	{
		private readonly DbHelper _dbHelper;

		public EmailHandler(DbHelper dbHelper) => _dbHelper = dbHelper;

		public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
		{
			await _dbHelper.EventOccured(notification.Product, "Email sent");
			await Task.CompletedTask;
		}
	}
}
