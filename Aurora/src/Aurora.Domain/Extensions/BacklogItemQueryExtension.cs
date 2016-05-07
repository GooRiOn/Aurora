using System.Linq;
using Aurora.DataAccess.Entities;
using Aurora.Infrastructure.Models.ReadModels;

namespace Aurora.Domain.Extensions
{
    public static class BacklogItemQueryExtension
    {
        public static IQueryable<BacklogItemReadModel> AsReadModel(this IQueryable<BacklogItemEntity> that)
        {
            return that.Select(b => new BacklogItemReadModel
            {
                Id = b.Id,
                SprintId = b.SprintId,
                SprintName = b.Sprint.Name,
                Title = b.Title,
                State = b.State
            });
        } 
    }
}
