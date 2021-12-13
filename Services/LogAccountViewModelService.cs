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
    public class LogAccountViewModelService : ILogAccountViewModelService
    {
        private readonly ILogAccountRepository _logAccountRepository;
        private readonly IMapper _mapper;

        public LogAccountViewModelService(ILogAccountRepository logAccountRepository, IMapper mapper)
        {
            _logAccountRepository = logAccountRepository;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            _logAccountRepository.Delete(id);
        }

        public LogAccountViewModel Get(int id)
        {
            var entity = _logAccountRepository.Get(id);
            if (entity == null)
                return null;

            return _mapper.Map<LogAccountViewModel>(entity);
        }

        public IEnumerable<LogAccountViewModel> GetAll()
        {
            var list = _logAccountRepository.GetAll();
            if (list == null)
                return new LogAccountViewModel[] { };

            return _mapper.Map<IEnumerable<LogAccountViewModel>>(list);
        }

        public IEnumerable<LogAccountViewModel> GetByDate(DateTime date)
        {
            var list = _logAccountRepository.GetByDate(date);
            if (list == null)
                return new LogAccountViewModel[] { };
            return _mapper.Map<IEnumerable<LogAccountViewModel>>(list);
        }

        public void Insert(LogAccountViewModel viewModel)
        {
            var entity = _mapper.Map<LogAccount>(viewModel);
            _logAccountRepository.Insert(entity);
        }

        public void Update(LogAccountViewModel viewModel)
        {
            var entity = _mapper.Map<LogAccount>(viewModel);

            _logAccountRepository.Update(entity);
        }
    }
}
