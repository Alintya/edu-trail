using EduTrail.Domain.Exceptions;
using EduTrail.Domain.Interfaces;
using EduTrail.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EduTrail.Infrastructure.Repositories;

public class Repository<T>(IDbContextFactory<ApplicationDbContext> contextFactory) : IRepository<T> where T : class
{
    private readonly IDbContextFactory<ApplicationDbContext> contextFactory = contextFactory;

    public virtual async Task<T> GetByIdAsync(Guid id)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.Set<T>().FindAsync(id) ?? throw new EntityNotFoundException();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.Set<T>().ToListAsync();
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        context.Set<T>().Update(entity);
        await context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }
}
