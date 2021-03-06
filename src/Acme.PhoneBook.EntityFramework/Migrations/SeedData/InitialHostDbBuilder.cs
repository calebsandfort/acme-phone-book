﻿using Acme.PhoneBook.EntityFramework;
using EntityFramework.DynamicFilters;

namespace Acme.PhoneBook.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly PhoneBookDbContext _context;

        public InitialHostDbBuilder(PhoneBookDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
