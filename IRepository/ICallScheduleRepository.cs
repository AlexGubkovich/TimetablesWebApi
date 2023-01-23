namespace TimetablesProject.IRepository
{
    public interface ICallScheduleRepository
    {
        Task GetAll();
        Task GetActive();
        Task Delete(int id);
        Task Update();
    }
}
