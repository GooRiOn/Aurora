using Aurora.DataAccess.Entities;
using Aurora.DataAccess.Repositories.Interfaces;

namespace Aurora.DataAccess.Repositories
{
    public class ProjectRepository : GenericRepository<ProjectEntity,int>, IProjectRepository
    {
        public ProjectRepository(AuroraContext context) : base(context)
        {
        }
    }
}
