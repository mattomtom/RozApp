using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RozApp.Models;
using SQLite;

namespace RozApp.Data
{
    public class Database
    {
        private readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Models.UserModel>().Wait();
        }

        public Task<List<Models.UserModel>> GetItemsAsync()
        {
            return database.Table<Models.UserModel>().ToListAsync();
        }

        public Task<int> SaveItemAsync(Models.UserModel item)
        {
            return database.InsertAsync(item);
        }
    }
}

