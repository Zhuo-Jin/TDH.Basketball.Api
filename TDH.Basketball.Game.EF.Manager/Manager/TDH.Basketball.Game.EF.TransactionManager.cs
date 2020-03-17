using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using TDH.Basketball.Game.EF.Core.EntityClasses;
using TDH.Basketball.Game.EF.Manager.Interface;
using TDH.Basketball.Game.EF.Repository;

namespace TDH.Basketball.Game.EF.Manager.Manager
{
    public class TransactionManager : ITransactionManager
    {
        protected readonly IGenericRepository<Transaction> _transactionRepository;
        protected readonly ILogger<Transaction> _logger;

        public TransactionManager(IGenericRepository<Transaction> transactionRepository, ILogger<Transaction> logger)
        {
            _transactionRepository = transactionRepository;
            _logger = logger;
        }

        public async Task<bool> AddTransactionAsync(Transaction Transaction)
        {
            // expect creation date is always the latest date

            Transaction.CreateDate = DateTime.Now;

            var lastBalance = (await _transactionRepository.GetAsync())?.OrderBy(t => t.CreateDate).LastOrDefault()?.Balance ?? 0;

            Transaction.Balance = Transaction.InOrOut ? lastBalance + Transaction.TransactionFee : lastBalance - Transaction.TransactionFee;

            return !(await _transactionRepository.CreateAsync(Transaction) is null);

        }

        public async Task<List<Transaction>> GetAllTransactionsAsync(DateTime Startdate, DateTime Enddate)
        {
            return (await _transactionRepository.GetAsync()).Where(t => t.CreateDate >= Startdate && t.CreateDate <= Enddate).ToList();
        }

        public async Task<Transaction> GetTransactionByIdAsync(int Id)
        {
            return await _transactionRepository.GetAsync(Id);
        }

        public async Task<bool> RemoveTransactionAsync(Transaction Transaction)
        {
            // remove transaction lead to a recaculation of the balance 
            try
            {
                var recalculateDate = Transaction.CreateDate;

                var lastBalance = (await _transactionRepository.GetAsync())?
                    .Where(t => t.CreateDate < Transaction.CreateDate)
                    .OrderBy(t => t.CreateDate).LastOrDefault()?.Balance ?? 0;

                var transactionBelowDeleting = (await _transactionRepository.GetAsync())?
                    .Where(t => t.CreateDate > Transaction.CreateDate).OrderBy(t => t.CreateDate);
                // recaluculating

                var successful = true;
                successful &= await _transactionRepository.DeleteAsync(Transaction);

                foreach (var trans in transactionBelowDeleting)
                {
                    lastBalance = trans.InOrOut ? lastBalance + trans.TransactionFee : lastBalance - trans.TransactionFee;
                    trans.Balance = lastBalance;

                    successful &= await _transactionRepository.UpdateAsync(trans.Id, trans);
                }

                return successful;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Module {nameof(TransactionManager)} in Function RemoveTransactionAsync Error : { ex.Message}");
                return false;
            }
            

            throw new NotImplementedException();
        }
    }
}

