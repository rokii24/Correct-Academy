

namespace Contract.AddDtos
{
    public record AddChatDto
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? ChatImage { get; set; }
    }
    public record UpdateMessagesDto
    {
        public Guid MesaageId { get; set; }
        public string Value { get; set; } = null!;
    }
    public record UpdateChatDto
    {
        public Guid ChatId { get; set; }
        public string? Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? ChatImage { get; set; }
    }
}
