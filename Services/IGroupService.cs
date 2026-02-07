using CollegeSchedule.DTO;

namespace CollegeSchedule.Services
{
    public interface IGroupService
    {
        Task<List<GroupDto>> GetAllGroupsAsync();
    }
}