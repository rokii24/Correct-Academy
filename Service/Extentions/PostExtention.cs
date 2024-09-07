using Contract.AddDtos;
using Contract.GetDtos;
using Domain.Entities.DataEntities;


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
            };
        }

    }
}
