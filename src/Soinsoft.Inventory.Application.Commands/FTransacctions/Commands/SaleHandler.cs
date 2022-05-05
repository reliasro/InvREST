using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Soinsoft.Inventory.Application.Commands.Events;
using Soinsoft.Inventory.Domain.Contracts;
using Soinsoft.Inventory.Domain.Model;

namespace Soinsoft.Inventory.Application.Commands.FTransacctions.Commands
{
    public class SaleHandler : IRequestHandler<SaleCmd, int>
    {

        private readonly IRepository<Transaction> _repoTrans;
        private readonly IMediator _mediator;

        public SaleHandler(IRepository<Transaction> repoTrans, IMediator mediator){
            _repoTrans = repoTrans;
            _mediator = mediator;
        }
        public async Task<int> Handle(SaleCmd request, CancellationToken cancellationToken)
        {
            //Event notification
            TransactionSaved transa= new TransactionSaved();
            transa.ProductId=request.ProductID;
            transa.ValueToAdjust=request.Value;

            Transaction tr = new Transaction();
            
            tr.Comments=request.Comments;
            tr.TransacctionType =request.TransacctionType;
            tr.Value =request.Value; //Reduce inventory
            tr.InitialExistence =request.InitialExistence;
            tr.ProductID =request.ProductID;
            tr.ProductDescription =request.ProductDescription;
            tr.Price =request.Price;
            tr.Date =request.Date;
            
            //Save to database
            await _repoTrans.Create(tr);
            await _repoTrans.SaveChanges();

            //Publish the purchase event
            await _mediator.Publish(transa);
            return 1;
        }
    }
}