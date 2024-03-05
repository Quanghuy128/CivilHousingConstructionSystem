using CHC.Domain.Common;

namespace CHC.Domain.Dtos.Feedback
{
    public class FeedbackDto : BaseEntity
    {
        public string Content { get; set; } = string.Empty;
    }
}
