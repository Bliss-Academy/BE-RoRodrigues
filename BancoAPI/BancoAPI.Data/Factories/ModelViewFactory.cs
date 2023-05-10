using AutoMapper;
using BancoAPI.Data.Entities;
using BancoAPI.Data.Models;
using BancoAPI.Data.Models.ModelViews;


namespace BancoAPI.Data.Factories
{
    public interface IModelViewFactory
    {
        DashboardViewModel GetDashboardDTO(AccountEntity account, List<TransactionEntity> transactions, List<TransactionEntity> timeframedTransactions);
        DashboardViewModel TesteGetDashboardandTransactionsDTO(DashboardDTO dashboardDTO, TimeFrame timeframe, List<TransactionDTO> transactions);
        TransactionsModelView GetTransactionsModelView(List<TransactionDTO> transactions);
        TransactionDTO addTransaction(NewTransactionViewModel transactions);
    }

    public class ModelViewFactory : IModelViewFactory
    {
        private readonly IMapper _mapper;

        public ModelViewFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public DashboardViewModel GetDashboardDTO(AccountEntity account, List<TransactionEntity> transactions, List<TransactionEntity> timeframedTransactions)
        {
            if (account != null)
            {
                var timeframedTransactionsDto = timeframedTransactions.OrderByDescending(t => t.created).Select(t => new TransactionDTO()
                {
                    id = t.id,
                    userId = t.userId,
                    title = t.title,
                    attachment = t.attachment,
                    Created = t.created,
                    description = t.description,
                    type = t.type,
                    value = t.value
                }).ToList();

                var lastTransactions = transactions.OrderByDescending(t => t.created).Take(3).Select(t => new TransactionDTO()
                {
                    id = t.id,
                    userId = t.userId,
                    title = t.title,
                    attachment = t.attachment,
                    Created = t.created,
                    description = t.description,
                    type = t.type,
                    value = t.value
                }).ToList();

                return new DashboardViewModel()
                {
                    income = account.income,
                    expense = account.expense,
                    balance = account.income - account.expense,
                    userId = account.userId,
                    username = account.username,
                    timeframedTransactions = timeframedTransactionsDto,
                    lastTransactions = lastTransactions
                };
            }
            else
                throw new Exception("User not found!");

        }

        public DashboardViewModel TesteGetDashboardandTransactionsDTO(DashboardDTO dashboardDTO, TimeFrame timeframe, List<TransactionDTO> transactions)
        {
            var minDate = DateTime.Now.AddDays(-(int)timeframe);
            var timeframedTransactionsEntity = transactions.Where(i => i.Created > minDate).OrderBy(t => t.Created).ToList();
            var timeframedTransactionsDto = _mapper.Map<List<TransactionDTO>>(timeframedTransactionsEntity);
            var lastTransactionsEntity = transactions.OrderByDescending(t => t.Created).Take(3).ToList();

            var lastTransactionsDto = _mapper.Map<List<TransactionDTO>>(lastTransactionsEntity);

            var model = _mapper.Map<DashboardViewModel>(dashboardDTO);

            model.timeframedTransactions = timeframedTransactionsDto;
            model.lastTransactions = lastTransactionsDto;

            return model;
        }

        public TransactionsModelView GetTransactionsModelView(List<TransactionDTO> transactions)
        {
            var TransactionsDto = _mapper.Map<TransactionsModelView>(transactions);
            return TransactionsDto;
        }

        public TransactionDTO addTransaction(NewTransactionViewModel transactions)
        {
            var newTransactionsDto = _mapper.Map<TransactionDTO>(transactions);

            return newTransactionsDto;
        }
    }
}