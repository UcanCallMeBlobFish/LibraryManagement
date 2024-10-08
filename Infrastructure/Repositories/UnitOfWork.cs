﻿using Application.Abstractions.Library;
using AutoMapper;
using Infrastructure.LibraryData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _context;

        public IAlertRepository Alerts { get; }
        public IAuthorRepository Authors { get; }
        public IBookOnShelfRepository BookOnShelves { get; }
        public IBookRepository Books { get; }
        public ICategoryRepository Categories { get; }
        public ICheckOutRepository CheckOuts { get; }
        public ICustomerRepository Customers { get; }
        public IEditorRepository Editors { get; }
        public IMapper Mapper { get; }

        public UnitOfWork(LibraryDbContext context,
                          IAlertRepository alerts,
                          IAuthorRepository authors,
                          IBookOnShelfRepository bookOnShelves,
                          IBookRepository books,
                          ICategoryRepository categories,
                          ICheckOutRepository checkOuts,
                          ICustomerRepository customers,
                          IEditorRepository editors,
                          IMapper mapper)
        {
            _context = context;
            Alerts = alerts;
            Authors = authors;
            BookOnShelves = bookOnShelves;
            Books = books;
            Categories = categories;
            CheckOuts = checkOuts;
            Customers = customers;
            Editors = editors;
            Mapper = mapper;
        }


        //For generic services.
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(_context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
