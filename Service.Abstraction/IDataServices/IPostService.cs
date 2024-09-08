using Contract.AddDtos;
using Contract.GetDtos;
using Contract.HubDtos;

namespace Service.Abstraction.IDataServices
{
    public interface IPostService
    {
        Task Add(AddPostDto Dto);
        Task Add(CommentDto Dto, string Type);
        Task Add(CommentReplyDto Dto, string Type);
        Task<ICollection<GetPostDto>> GetAll();
        Task<ICollection<GetPostDto>> GetAllPublic();
        Task<ICollection<GetPostDto>> GetAllByUser(string Id);
        Task DeletePost(Guid PostId);
        Task DeleteComment(Guid CommentId);
        Task UpdatePost(UpdatePostDto Dto);
        Task UpdateComment(UpdateComment Dto);
    }
}
