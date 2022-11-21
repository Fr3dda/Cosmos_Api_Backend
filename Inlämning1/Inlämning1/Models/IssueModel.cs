namespace Inlämning1.Models
{
    public class IssueModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedDate {get; set; }
        public byte IssueStatus { get; set; }
        public string IssueMessage { get; set; }
    }
}
