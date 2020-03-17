using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDH.Basketball.Game.EF.Core.EntityClasses;

namespace TDH.Basketball.Game.EF.Manager.Interface
{
    public interface ITermManager
    {

        Task<List<Term>> GetAllTermsAsync(DateTime Startdate, DateTime EndDate);

        Task<Term> GetTermByIdAsync(int Id);


        Task<bool> AddOrUpdateTermAsync(Term Term);
        Task<bool> RemoveTermAsync(Term Term);
    }
}
