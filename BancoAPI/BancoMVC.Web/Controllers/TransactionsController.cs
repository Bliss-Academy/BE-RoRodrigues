using Microsoft.AspNetCore.Mvc;
using BancoAPI.Data.Models.ModelViews;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using BancoAPI.Business.Services;
using System.Drawing;
using BancoAPI.Data.Factories;
using BancoAPI.Data.Entities;
using BancoAPI.Data.Models;

namespace BancoMVC.Web.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly ITransactionService _transactionService;
        private readonly IModelViewFactory _modelViewFactory;

        public TransactionsController(ILogger<DashboardController> logger, ITransactionService transactionService, IModelViewFactory modelViewFactory)
        {
            _logger = logger;
            _transactionService = transactionService;
            _modelViewFactory = modelViewFactory;
        }

        public IActionResult Index(string userId)
        {
            try
            {
                var model = _transactionService.getTransactionsModelView(userId);
                return View("Transactions", model);
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
        }

        public IActionResult AdicionarIncomeView(NewTransactionViewModel model)
        {
            return View("AddIncome");
        }

        public IActionResult AdicionarIncome(NewTransactionViewModel model)
        {
            model.userId = "1";
            model.attachment = "string";
            model.type = TrasactionType.Income;
            model.Created= DateTime.Now;

            var transacao = _modelViewFactory.addTransaction(model);
            
            _transactionService.AddTransactionViewModel(transacao);

            return RedirectToAction("Index");
        }

        public IActionResult AdicionarExpenseView()
        {
            return View("AddExpense");
        }

        public IActionResult AdicionarExpense(NewTransactionViewModel model)
        {
            model.userId = "1";
            model.attachment = "string";
            model.type = TrasactionType.Expense;
            model.Created = DateTime.Now;

            var transacao = _modelViewFactory.addTransaction(model);

            _transactionService.AddTransactionViewModel(transacao);

            return RedirectToAction("Index");
        }

        public IActionResult EditarTransactionView(int Id)
        {
            var transactionDTO = _transactionService.FindTransactionById(Id);
            return View("EditTransaction",transactionDTO);
        }

        public IActionResult EditarTransaction(TransactionDTO transaction)
        {


            var model = _transactionService.EditTransactionViewModel(transaction);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteTransaction(int? Id, TrasactionType type)
        {
            if (Id is null)
            {
                return RedirectToAction("Index");
            }else
                _transactionService.DeleteTransactionMV(Id.Value,type);

            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
