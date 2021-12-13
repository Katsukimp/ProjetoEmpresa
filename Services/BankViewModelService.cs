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
    public class BankViewModelService : IBankViewModelService
    {
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;

        public BankViewModelService(IBankRepository bankRepository, IMapper mapper)
        {
            _bankRepository = bankRepository;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            _bankRepository.Delete(id);
        }

        public BankViewModel Get(int id)
        {
            var entity = _bankRepository.Get(id);
            if (entity == null)
                return null;

            return _mapper.Map<BankViewModel>(entity);
        }

        public IEnumerable<BankViewModel> GetAll()
        {
            var list = _bankRepository.GetAll();
            if (list == null)
                return new BankViewModel[] { };

            return _mapper.Map<IEnumerable<BankViewModel>>(list);
        }

        public void Insert(BankViewModel viewModel)
        {
            var entity = _mapper.Map<Bank>(viewModel);
            _bankRepository.Insert(entity);
        }

        public void Update(BankViewModel viewModel)
        {
            var entity = _mapper.Map<Bank>(viewModel);

            _bankRepository.Update(entity);
        }
    }
}
