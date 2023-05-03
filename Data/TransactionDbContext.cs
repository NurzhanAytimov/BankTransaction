using BankTransaction.Models;
using Microsoft.EntityFrameworkCore;

namespace BankTransaction.Data
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }  
    }
}
