using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Soinsoft.Inventory.Application.Commands.FProduct.Commands;

namespace Soinsoft.Inventory.Application.Commands.Events
{
    public class TransacSavedHandler : INotificationHandler<TransactionSaved>
    {
        private readonly IMediator _mediator;
        public TransacSavedHandler(IMediator mediator){
            _mediator = mediator;

        }

        public Task Handle(TransactionSaved notification, CancellationToken cancellationToken)
        {
           
           //This event trigger an inventory update
           UpdateExistenceCmd upe = new UpdateExistenceCmd();
           upe.ProductId=notification.ProductId;
           upe.ValueToAdjust=notification.ValueToAdjust;
           upe.TransactionType=notification.TransactionType;
           return _mediator.Send(upe);

        }
    }
}