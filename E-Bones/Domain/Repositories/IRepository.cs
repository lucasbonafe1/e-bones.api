namespace E_Bones.Domain.Repositories
{
    public interface IRepository<TEntity, Id> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);
        Task<List<TEntity>> GetAll();
        Task<TEntity?> GetById(Id id);
        Task<TEntity?> Update(TEntity entity, Id id);
        Task<bool> Delete(Id id);
    }
}
