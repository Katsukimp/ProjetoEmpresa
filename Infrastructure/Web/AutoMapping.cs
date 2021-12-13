using AutoMapper;
using HiringTest.Domain.Entities;
using HiringTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringTest.Infrastructure.Web
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Bank, BankViewModel>();
            CreateMap<BankViewModel, Bank>();
            CreateMap<Person, PersonViewModel>();
            CreateMap<PersonViewModel, Person>();
            CreateMap<Account, AccountViewModel>()
                .ForMember(a => a.Person, b => b.MapFrom(c => c.Person.Name))
                .ForMember(a => a.Bank, b => b.MapFrom(c => c.Bank.Name));
            CreateMap<AccountViewModel, Account>();
            CreateMap<LogAccount, LogAccountViewModel>()
                .ForMember(a => a.Account, b => b.MapFrom(c => c.Account.AccountNumber));
            CreateMap<LogAccountViewModel, LogAccount>();
        }
    }
}
