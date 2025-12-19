namespace EasySchoolManager.Api.Services.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class 
    {
        Task<T> CreateAsync(T value);
        Task<IEnumerable<T>> ReadAllAsync(bool active = true);
        Task<T?> ReadByIdAsync(Guid id);
        Task<int> UpdateAsync(T value,Guid whoEdited);
        Task<int> RestoreByAsync(Guid id, Guid whoRestored);
        Task<int> DeleteByAsync(Guid id, Guid whoDeleted);
    }
}
