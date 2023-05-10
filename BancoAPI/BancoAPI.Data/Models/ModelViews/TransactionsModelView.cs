using BancoAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoAPI.Data.Models.ModelViews
{
    public class TransactionsModelView : BaseViewModel
    {
        public List<TransactionDTO> transactions { get; set; }
    }
}
