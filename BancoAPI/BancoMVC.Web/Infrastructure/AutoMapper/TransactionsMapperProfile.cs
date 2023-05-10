using AutoMapper;
using BancoAPI.Data.Entities;
using BancoAPI.Data.Models;
using BancoAPI.Data.Models.ModelViews;

namespace BancoMVC.Web.Infrastructure.AutoMapper
{
    public class TransactionsMapperProfile : Profile
    {
        public TransactionsMapperProfile() {
            CreateMap<TransactionEntity, TransactionDTO>().ReverseMap();

            CreateMap<NewTransactionViewModel, TransactionDTO>().ReverseMap();
        }

    }
}
