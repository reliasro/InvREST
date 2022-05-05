using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Soinsoft.Inventory.Application.Commands.FProduct.Commands;

namespace Soinsoft.Inventory.Application.Commands.Events
{
    public class TransaccSavedHandler : INotificationHandler<TransacctionSaved>
    {
        private readonly IMediator _mediator;
        public TransaccSavedHandler(IMediator mediator){
            _mediator = mediator;

        }

        public Task Handle(TransacctionSaved notification, CancellationToken cancellationToken)
        {
           
           //This event trigger an inventory update
           UpdateExistenceCmd upe = new UpdateExistenceCmd();
           upe.ProductId=notification.ProductId;
           upe.ValueToAdjust=notification.ValueToAdjust;
           return _mediator.Send(upe);

        }
    }
}