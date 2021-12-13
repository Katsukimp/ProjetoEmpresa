using HiringTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringTest.Interface
{
    public interface IPersonViewModelService
    {
        PersonViewModel Get(int id);
        IEnumerable<PersonViewModel> GetAll();
        void Insert(PersonViewModel viewModel);
        void Update(PersonViewModel viewModel);
        void Delete(int id);
    }
}
