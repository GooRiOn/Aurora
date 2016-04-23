using System.Linq;
using Aurora.DataAccess.Entities;
using Aurora.Infrastructure.Models.ReadModels;

namespace Aurora.Domain.Extensions
{
    public static class SprintQueryExtensions
    {
        public static IQueryable<SprintReadModel> AsReadModel(this IQueryable<SprintEntity> that)
        {
            return that.Select(s => new SprintReadModel
            {
                Id = s.Id,
                ProjectId = s.ProjectId,
                Name = s.Name,
                EstimatedStartDate = s.EstimatedStartDate,
                EstimatedEndDate = s.EstimatedEndDate,
                State = s.State
            });
        } 
    }
}
