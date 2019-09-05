﻿using practice_3.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace practice_3
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            //Establishing the conection
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Contact>().Wait();
        }

        // Show the registers
        public Task<List<Contact>> GetPeopleAsync()
        {
            return _database.Table<Contact>().ToListAsync();
        }

        // Save registers
        public Task<int> SavePersonAsync(Contact contact)
        {
            return _database.InsertAsync(contact);
        }

        // Delete registers
        public Task<int> DeletePersonAsync(Contact contact)
        {
            return _database.DeleteAsync(contact);
        }

        // Save registers
        public Task<int> UpdatePersonAsync(Contact contact)
        {
            return _database.UpdateAsync(contact);
        }
    }
}
