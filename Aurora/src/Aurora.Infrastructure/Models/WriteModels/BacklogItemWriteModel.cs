using Aurora.Infrastructure.Enums;

namespace Aurora.Infrastructure.Models.WriteModels
{
    public class BacklogItemWriteModel
    {
        public int SprintId { get; set; }

        public string Title { get; set; }

        public BacklogItemState State { get; set; }
    }
}
