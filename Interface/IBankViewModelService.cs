using HiringTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringTest.Interface
{
    public interface IBankViewModelService
    {
        BankViewModel Get(int id);
        IEnumerable<BankViewModel> GetAll();
        void Insert(BankViewModel viewModel);
        void Update(BankViewModel viewModel);
        void Delete(int id);
    }
}
