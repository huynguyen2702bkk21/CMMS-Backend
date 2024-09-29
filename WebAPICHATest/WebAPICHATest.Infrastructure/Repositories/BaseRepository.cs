﻿using WebAPICHATest.Domain.SeedWork;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Infrastructure.Repositories;
public class BaseRepository
{
    protected readonly ApplicationDbContext _context;
    public IUnitOfWork UnitOfWork
    {
        get
        {
            return _context;
        }
    }

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
}
