using HiringTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringTest.Interface
{
    public interface ILogAccountViewModelService
    {
        LogAccountViewModel Get(int id);
        IEnumerable<LogAccountViewModel> GetAll();
        IEnumerable<LogAccountViewModel> GetByDate(DateTime date);
        void Insert(LogAccountViewModel viewModel);
        void Update(LogAccountViewModel viewModel);
        void Delete(int id);
    }
}
