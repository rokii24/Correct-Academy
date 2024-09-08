using Contract.AddDtos;
using Contract.GetDtos;
using Contract.HubDtos;

namespace Service.Abstraction.IDataServices
{
    public interface IPostService
    {
        Task Add(AddPostDto Dto);
        Task Add(CommentDto Dto);
        Task Add(CommentReplyDto Dto);
        ICollection<GetPostDto> GetAll();
        ICollection<GetPostDto> GetAllPublic();
        ICollection<GetPostDto> GetAllByUser(string Id);
        Task DeletePost(Guid PostId);
        Task DeleteComment(Guid CommentId);
        Task UpdatePost(Guid CommentId);
        Task UpdateComment(Guid CommentId);
    }
}
