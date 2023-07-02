﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Threading;
using System.Threading.Tasks;
using SharedModels;

namespace SharedInfrastructure;

public interface IContext : IAsyncDisposable, IDisposable
{
    public DatabaseFacade Database { get; }
    
    public DbSet<AQIDataPoint> AQIDataPoints { get; }
    
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}