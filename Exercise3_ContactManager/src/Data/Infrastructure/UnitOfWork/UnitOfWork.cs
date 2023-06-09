using Domain;
using Infrastructure.Repo;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
	#region variables
	private readonly UserManagerDbContext _context;
	private readonly Dictionary<string, object> _repositories;
	#endregion
	
	#region constructors
	public UnitOfWork(UserManagerDbContext context)
	{
		_context = context;
		_repositories = new Dictionary<string, object>();
	}
	#endregion

	#region IUnitOfWork implementation
	public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
	{
		var type = typeof(TEntity);

		if (_repositories.TryGetValue(type.Name, out var repository)) 
			return (IRepository<TEntity>)repository;
		
		var repoType = typeof(Repository<>).MakeGenericType(type);
		var repo = Activator.CreateInstance(repoType, _context);

		if (repo != null)
			_repositories.Add(type.Name, repo);

		return (IRepository<TEntity>)_repositories[type.Name];
	}

	public async Task<int> SaveAsync(CancellationToken cancellationToken)
		=> await _context.SaveChangesAsync(cancellationToken);
	#endregion

	#region IDispose implementation
	public void Dispose() => _context.Dispose();
	#endregion
}