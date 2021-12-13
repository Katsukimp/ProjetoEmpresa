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
    public class PersonViewModelService : IPersonViewModelService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonViewModelService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            _personRepository.Delete(id);
        }

        public PersonViewModel Get(int id)
        {
            var entity = _personRepository.Get(id);
            if (entity == null)
                return null;

            return _mapper.Map<PersonViewModel>(entity);
        }

        public IEnumerable<PersonViewModel> GetAll()
        {
            var list = _personRepository.GetAll();
            if (list == null)
                return new PersonViewModel[] { };

            return _mapper.Map<IEnumerable<PersonViewModel>>(list);
        }

        public void Insert(PersonViewModel viewModel)
        {
            var entity = _mapper.Map<Person>(viewModel);
            _personRepository.Insert(entity);
        }

        public void Update(PersonViewModel viewModel)
        {
            var entity = _mapper.Map<Person>(viewModel);

            _personRepository.Update(entity);
        }
    }
}
