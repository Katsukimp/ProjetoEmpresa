using AutoMapper;
using HiringTest.Domain.Entities;
using HiringTest.Domain.Interfaces;
using HiringTest.Interface;
using HiringTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringTest.Services
{
    public class AccountViewModelService : IAccountViewModelService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountViewModelService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            _accountRepository.Delete(id);
        }

        public AccountViewModel Get(int id)
        {
            var entity = _accountRepository.Get(id);
            if (entity == null)
                return null;

            return _mapper.Map<AccountViewModel>(entity);
        }

        public IEnumerable<AccountViewModel> GetAll()
        {
            var list = _accountRepository.GetAll();
            if (list == null)
                return new AccountViewModel[] { };

            return _mapper.Map<IEnumerable<AccountViewModel>>(list);
        }

        public IEnumerable<AccountViewModel> GetByDate(DateTime date)
        {
            
        }

        public void Insert(AccountViewModel viewModel)
        {
            var entity = _mapper.Map<Account>(viewModel);
            _accountRepository.Insert(entity);
        }

        public void Update(AccountViewModel viewModel)
        {
            var entity = _mapper.Map<Account>(viewModel);

            _accountRepository.Update(entity);
        }
    }
}
