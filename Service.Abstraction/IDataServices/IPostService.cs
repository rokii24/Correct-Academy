using Contract.AddDtos;
using Contract.GetDtos;
using Contract.HubDtos;

namespace Service.Abstraction.IDataServices
{
    public interface IPostService
    {
        Task<Guid> Add(AddPostDto Dto);
        Task<string> Add(CommentDto Dto, string Type);
        Task<string> Add(CommentReplyDto Dto, string Type);
        Task<ICollection<GetPostDto>> GetAll();
        Task<ICollection<GetPostDto>> GetAllPostOfAcademy(Guid Id);
        Task<ICollection<GetPostDto>> GetAllPublic();
        Task<ICollection<GetPostDto>> GetAllByUser(string Id);
        Task<ICollection<GetCommentDto>> GetAllCommentOfPost(Guid Id);
        Task<GetPostDto> Get(Guid Id);
        Task DeletePost(Guid PostId);
        Task DeleteComment(Guid CommentId);
        Task UpdatePost(UpdatePostDto Dto);
        Task UpdatePost(UpdatePostImagesDto Dto);

        Task UpdateComment(UpdateComment Dto);
    }
}
