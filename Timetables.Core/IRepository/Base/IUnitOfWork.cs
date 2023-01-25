namespace Timetables.Core.IRepository.Base
{
    public interface IUnitOfWork
    {
        IGroupRepository Group { get; }
        ISubjectRepository Subject { get; }
        ITeacherRepository Teacher { get; }
        
        Task SaveAsync();
    }
}
