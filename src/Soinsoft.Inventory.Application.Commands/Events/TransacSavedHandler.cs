using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Soinsoft.Inventory.Application.Commands.FProduct.Commands;

namespace Soinsoft.Inventory.Application.Commands.Events
{
    public class TransacSavedHandler : INotificationHandler<TransactionSaved>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public TransacSavedHandler(IMediator mediator, IMapper mapper ){
            _mapper = mapper;
            _mediator = mediator;

        }

        public Task Handle(TransactionSaved notification, CancellationToken cancellationToken)
        {
         
           //This event trigger an inventory update command
           UpdateExistenceCmd updateExist = new UpdateExistenceCmd();
           updateExist= _mapper.Map<UpdateExistenceCmd>(notification);
           /*   
           updateExist.ProductId=notification.ProductId;
           updateExist.ValueToAdjust=notification.ValueToAdjust;
           updateExist.TransactionType=notification.TransactionType;
           */
           return _mediator.Send(updateExist);
        }
    }
}