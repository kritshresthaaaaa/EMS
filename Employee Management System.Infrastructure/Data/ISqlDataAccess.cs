namespace Employee_Management_System.Infrastructure.Data
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> GetData<T, P>(string sql, P parameters);
        Task SaveData<T>(string sql, T parameters);

        string ConnectionString { get; }
    }
}
