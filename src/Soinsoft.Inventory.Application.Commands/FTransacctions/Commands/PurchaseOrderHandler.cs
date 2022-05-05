using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Soinsoft.Inventory.Domain.Contracts;
using Soinsoft.Inventory.Domain.Model;
using Soinsoft.Inventory.Application.Commands.Events;

namespace Soinsoft.Inventory.Application.Commands.FTransacctions.Commands
{
    public class PurchaseOrderHandler : IRequestHandler<PurchaseOrderCmd, int>
    {
        private readonly IRepository<Transaction> _repoTrans;
        private readonly IMediator _mediator;

        public PurchaseOrderHandler(IRepository<Transaction> repoTrans, IMediator mediator){
            _repoTrans = repoTrans;
            _mediator = mediator;
        }

        public async Task<int> Handle(PurchaseOrderCmd request, CancellationToken cancellationToken)
        {
            //Events notification
            TransacctionSaved transa= new TransacctionSaved();
            transa.ProductId=request.ProductID;
            transa.ValueToAdjust=request.Value;

            Transaction tr = new Transaction();
            
            tr.Comments=request.Comments;
            tr.TransacctionType =request.TransacctionType;
            tr.Value =request.Value;
            tr.InitialExistence =request.InitialExistence;
            tr.ProductID =request.ProductID;
            tr.ProductDescription =request.ProductDescription;
            tr.Price =request.Price;
            tr.Date =request.Date;
            
            //Save to database
            await _repoTrans.Create(tr);
            await _repoTrans.SaveChanges();

            //Publish the event
            await _mediator.Publish(transa);
            return 1;

        }
    }
}