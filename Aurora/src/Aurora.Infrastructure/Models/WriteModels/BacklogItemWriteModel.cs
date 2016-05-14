using Aurora.Infrastructure.Enums;

namespace Aurora.Infrastructure.Models.WriteModels
{
    public class BacklogItemWriteModel
    {
        public int Id { get; set; }

        public int SprintId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public BacklogItemState State { get; set; }
    }
}
