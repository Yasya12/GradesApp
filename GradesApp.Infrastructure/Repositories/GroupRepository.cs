using GradesApp.Domain.Entities;
using GradesApp.Domain.Interfaces.Repositories;
using GradesApp.Infrastructure.Data;
using Group = System.Text.RegularExpressions.Group;

namespace GradesApp.Infrastructure.Repositories;

public class GroupRepository: GenericRepository<Group>, IGroupRepository
{
    public GroupRepository(GradesAppDbContext context) : base(context) { }
}