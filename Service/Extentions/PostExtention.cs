using Contract.AddDtos;
using Contract.GetDtos;
using Contract.HubDtos;
using Domain.Entities.DataEntities;
using Domain.Enums;
using Domain.Exceptions;


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
            var Images = new List<string>();    
            if (Post.Images !=null)
            {
                foreach (var image in Images)
                {

                    // Ensure the directory exists
                    if (!File.Exists(image))
                    {
                        throw new NotFoundException("The cve directory does not exist.");
                    }

                    byte[] imageBytes = System.IO.File.ReadAllBytes(image);


                    string base64String = Convert.ToBase64String(imageBytes);
                    Images.Add(base64String);

                }
            }
           
            return new GetPostDto
            {
                AddingDate = Post.AddingDate,
                Description = Post.Description,
                IsPublic = Post.IsPublic,
                Title = Post.Title,
                UserId = Post.UserId,
                Images = Images,
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
        public static GetCommentDto ToCommentDto(this Comment comment)
        {
            
            return new GetCommentDto
            {
                Message = comment.Value,
                UserId= Guid.Parse(comment.UserId),
                CommentId =comment.Id,
                Type = comment.Type.ToString(),
                UserImage = comment.User.UserImage,
                UserName = comment.User.Name
            };
        }
        public static ICollection<GetCommentDto> ToCommentDto(this ICollection<Comment> Comments)
        {
            var GetCommentDto = new List<GetCommentDto>();
            foreach (var comment in Comments)
            {
                GetCommentDto.Add(ToCommentDto(comment));
            }
            return GetCommentDto;
        }

    }
}
