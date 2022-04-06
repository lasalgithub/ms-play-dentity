using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Identity;
using Play.Identity.Contracts;
using Play.Identity.Entities;
using Play.Inventory.Exceptions;

namespace Play.Identity.Consumers
{
    public class DebitCashConsumer : IConsumer<DebitCash>
    {
        private readonly UserManager<ApplicationUser> userManager;

        public DebitCashConsumer(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task Consume(ConsumeContext<DebitCash> context)
        {
            var message = context.Message;

            var user = await userManager.FindByIdAsync(message.UserId.ToString());

            if (user == null)
            {
                throw new UnknownUserException(message.UserId);
            }

            user.Cash -= message.Cash;

            if (user.Cash < 0)
            {
                throw new InsufficientFundsException(message.UserId, message.Cash);
            }

            await userManager.UpdateAsync(user);

            await context.Publish(new CashDebited(message.CorrelationId));
        }
    }
}