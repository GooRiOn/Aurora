using Aurora.Infrastructure.Enums;

namespace Aurora.Infrastructure.Models.ReadModels
{
    public class BacklogItemReadModel
    {
        public int Id { get; set; }

        public int SprintId { get; set; }

        public string SprintName { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public BacklogItemState State { get; set; }
    }
}
