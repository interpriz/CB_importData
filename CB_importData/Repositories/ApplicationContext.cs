using CB_importData.Models;
using CB_importData.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CB_importData
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }

        public void importData(List<User> users)
        {
            Users.RemoveRange(Users);
            foreach (var u in users)
                Users.Add(u);
            SaveChanges();
        }

        public void addUser(User user)
        {
            Users.Add(user);
            SaveChanges();
        }

        public void removeUser(User user)
        {
            Users.Remove(user);
            SaveChanges();
        }

        public void updateUser(User user)
        {
            Entry(user).State = EntityState.Modified;
            SaveChanges();
        }
    }
}
