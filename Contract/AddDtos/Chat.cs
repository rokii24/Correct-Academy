

namespace Contract.AddDtos
{
    public record AddChatDto
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? ChatImage { get; set; }
    }
}
