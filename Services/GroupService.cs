using CollegeSchedule.Data;
using CollegeSchedule.DTO;
using CollegeSchedule.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeSchedule.Services
{
    public class GroupService : IGroupService
    {
        private readonly AppDbContext _db;

        public GroupService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<GroupDto>> GetAllGroupsAsync()
        {
            var groups = await _db.StudentGroups
                .Include(g => g.Specialty)
                .OrderBy(g => g.Course)
                .ThenBy(g => g.GroupName)
                .ToListAsync();

            return groups.Select(g => new GroupDto
            {
                GroupId = g.GroupId,
                GroupName = g.GroupName,
                Course = g.Course,
                SpecialtyName = g.Specialty.Name
            }).ToList();
        }
    }
}