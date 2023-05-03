using BankTransaction.Data;
using BankTransaction.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankTransaction.Controllers
{
    public class BankTransactionsController : Controller
    {
        private readonly TransactionDbContext transactionDbContext;

        public BankTransactionsController(TransactionDbContext _transactionDbContext)
        {
            transactionDbContext = _transactionDbContext;
        }
        public IActionResult Index()
        {
            var transaction = transactionDbContext.Transactions.ToList();
            return View(transaction);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                if (transaction.Id == 0)
                {
                    transaction.Date = DateTime.Now;
                    transactionDbContext.Transactions.Add(transaction);
                    transactionDbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                    return NotFound();
            }
            return View(transaction);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var transaction = transactionDbContext.Transactions.Find(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }

       
        [HttpPost]
        public IActionResult Edit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                transactionDbContext.Transactions.Update(transaction);
                transactionDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var transaction = transactionDbContext.Transactions.Find(id);
            
            transactionDbContext.Transactions.Remove(transaction);
            transactionDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
