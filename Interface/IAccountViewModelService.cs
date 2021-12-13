using HiringTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringTest.Interface
{
    public interface IAccountViewModelService
    {
        AccountViewModel Get(int id);
        IEnumerable<AccountViewModel> GetAll();
        void Insert(AccountViewModel viewModel);
        void Update(AccountViewModel viewModel);
        void Delete(int id);
    }
}
