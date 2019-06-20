using Plugin.SQLiteConnection;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ButceApp.Models
{
    public class DbManager
    {
        private SQLite.SQLiteConnection Connection;
        public DbManager()
        {
            CrossSQLiteConnection.Current.CreateConnection("tester.db3");
            Connection = CrossSQLiteConnection.Current.Connection;
            
                CreateExpense();

                CreateIncomes();
            
        }
        public TableQuery<Income> GetIncomes()
        {
            return  Connection.Table<Income>();
        }
        public TableQuery<Expense> GetExpenses()
        {
            return Connection.Table<Expense>();
        }
        private void CreateIncomes ()
        {
            Connection.CreateTable<Income>();
            var c1 = new Income() { Name = "Maaş", Amounth = 150, Continious = true, Time = new DateTime() };
            //Connection.Insert(c1);
        }
        private void CreateExpense()
        {
            Connection.CreateTable<Expense>();
            var c1 = new Expense() { Name = "Harcama", Amounth = 100, Continious = true, Time = new DateTime() };
          //  Connection.Insert(c1);
        }
        public void Delete<T>(T model)
        {
            Connection.Delete(model);
        }
        public void Insert<T>( T model )
        {
            Connection.Insert(model);
        }
    }
}
