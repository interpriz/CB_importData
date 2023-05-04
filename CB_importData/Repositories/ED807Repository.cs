using CB_importData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_importData.Repositories
{
    class ED807Repository : DbContext
    {
        public DbSet<ED807> ED807 { get; set; } = null!;
        public DbSet<BICDirectoryEntry> BICDirectoryEntry { get; set; } = null!;
        public DbSet<ParticipantInfo> ParticipantInfo { get; set; } = null!;
        public DbSet<Accounts> Accounts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ED807.db");
        }

        public void importData(List<ED807> records)
        {
            ED807.Add(records[0]);
            SaveChanges();

        }

        public List<Accounts> simpleSerch(int BIC)
        {
            var accounts = (from account in Accounts
                         where account.bICDirectoryEntry.BIC== BIC
                            select account).ToList();
            return accounts;
        }
    }
}
