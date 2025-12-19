using EasySchoolManager.Api.Services.Interfaces.Repository;
using EasySchoolManager.Infra;
using EasySchoolManager.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace EasySchoolManager.Api.Services.Implementations.Repository
{
    public class BaseRepository<T>(DataBaseContext dataBase) : IBaseRepository<T> where T : class, IBaseEntity
    {
        protected readonly DataBaseContext _dataBase = dataBase;
        protected readonly DbSet<T> _dataContext = dataBase.Set<T>();

        public async Task<T> CreateAsync(T value)
        {
            await _dataContext.AddAsync(value);

            await _dataBase.SaveChangesAsync();

            return value;
        }

        public async Task<T?> ReadByIdAsync(Guid id)
        {
            return await _dataContext.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> ReadAllAsync(bool active = true)
        {
            var query = _dataContext.AsNoTracking().AsQueryable();

            if (active)
                query = query.Where(x => !x.IsDeleted);

            var result = await query.ToListAsync();

            return result;
        }

        public async Task<int> UpdateAsync(T value, Guid whoEdited)
        {
            value.LastUpdatedBy = whoEdited;
            value.LastUpdateDate = DateTime.UtcNow;

            _dataBase.Update(value);

            return await _dataBase.SaveChangesAsync();
        }

        public async Task<int> RestoreByAsync(Guid id, Guid whoRestored)
        {
            var result = await ReadByIdAsync(id);

            if (result is null)
                return 0;

            if (!result.IsDeleted)
                throw new ArgumentException(nameof(T),"is not deleted");

            result.IsDeleted = false;
            result.DeletedBy = null;
            result.DeletedDate = null;

            return await _dataBase.SaveChangesAsync();
        }

        public async Task<int> DeleteByAsync(Guid id, Guid whoDeleted)
        {
            var result = await ReadByIdAsync(id);

            if (result is null)
                return 0;

            if (result.IsDeleted)
                throw new ArgumentException(nameof(T),"is already deleted");

            result.IsDeleted = true;
            result.DeletedBy = whoDeleted;
            result.DeletedDate = DateTime.UtcNow;

            return await _dataBase.SaveChangesAsync();
        }
    }
}
