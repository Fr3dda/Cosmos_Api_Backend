namespace Inlämning1.Models
{
    public class IssueModelRequest
    {
        public string? Title { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string IssueMessage { get; set; }

    }
}
