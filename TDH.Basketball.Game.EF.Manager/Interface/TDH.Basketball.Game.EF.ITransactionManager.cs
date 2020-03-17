using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDH.Basketball.Game.EF.Core.EntityClasses;

namespace TDH.Basketball.Game.EF.Manager.Interface
{
    public interface ITransactionManager
    {
        Task<List<Transaction>> GetAllTransactionsAsync(DateTime Startdate, DateTime Enddate);

        Task<Transaction> GetTransactionByIdAsync(int Id);

        Task<bool> AddTransactionAsync(Transaction Transaction);
        Task<bool> RemoveTransactionAsync(Transaction Transaction);

    }
}
