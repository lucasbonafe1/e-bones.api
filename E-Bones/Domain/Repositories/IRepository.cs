namespace E_Bones.Domain.Repositories
{
    public interface IRepository<TEntity, Id> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity?> GetById(Id id);
        Task<TEntity?> Update(TEntity entity, int id);
        Task<bool> Delete(int id);
    }
}
