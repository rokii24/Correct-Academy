using Contract.AddDtos;
using Contract.GetDtos;
using Contract.HubDtos;
using Domain.Entities.DataEntities;
using Domain.Enums;


namespace Service.Extentions
{
    public static class PostExtention 
    {
       public static Post ToPost(this AddPostDto Dto)
       {
            return new Post
            {
                AddingDate = Dto.AddingDate,
                Description = Dto.Description,  
                IsPublic = Dto.IsPublic,    
                Title = Dto.Title   ,
                UserId = Dto.UserId ,
                Images = Dto.Images ,   
            };
       }

        public static GetPostDto ToPostDto(this Post Post)
        {
            return new GetPostDto
            {
                AddingDate = Post.AddingDate,
                Description = Post.Description,
                IsPublic = Post.IsPublic,
                Title = Post.Title,
                UserId = Post.UserId,
                Images = Post.Images,
                UserImage = Post.User.UserImage,
                UserName = Post.User.Name ,
                PostId = Post.Id ,
            };
        }
        public static ICollection<GetPostDto> ToPostDto(this ICollection<Post> Posts)
        {
            var GetPostDtos = new List<GetPostDto>();   
            foreach (var Post in Posts)
            {
                GetPostDtos.Add(ToPostDto(Post));
            }
            return GetPostDtos;
        }
        public static Comment ToComment(this CommentDto Dto,string Type)
        {
            MessageType messageType = MessageType.Text;
            Enum.TryParse<MessageType>(Type,true, out messageType);
            return new Comment
            {
                Value = Dto.Message,
                UserId= Dto.UserId,
                PostId =Guid.Parse(Dto.PostId) ,
                Type = messageType,               
            };
        }
        public static Comment ToCommentReply(this CommentReplyDto Dto, string Type)
        {
            MessageType messageType = MessageType.Text;
            Enum.TryParse<MessageType>(Type, true, out messageType);
            return new Comment
            {
                Value = Dto.Message,
                UserId= Dto.UserId,
                PostId =Guid.Parse(Dto.PostId),
                Type = messageType,  
            };
        }

    }
}
