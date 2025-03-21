﻿using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        private readonly DbContextBook _context;

        public UserRL(DbContextBook context)
        {
            _context = context;
        }

        public UserContactBook? GetUserByEmail(string email)
        {
            try
            {
                return _context.UserContactBooks.AsNoTracking().FirstOrDefault(u => u.Email == email);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetUserByEmail] Error: {ex.Message}");
                return null;
            }
        }

        public void AddUser(UserContactBook user)
        {
            try
            {
                _context.UserContactBooks.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[AddUser] Error: {ex.Message}");
            }
        }

        public void UpdateUser(UserContactBook user)
        {
            _context.UserContactBooks.Update(user);
            _context.SaveChanges();
        }
    }
}
