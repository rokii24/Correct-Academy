using Contract.AddDtos;
using Contract.GetDtos;
using Contract.HubDtos;
using Domain.Entities.DataEntities;
using Domain.Exceptions;
using Domain.IRepositories.DataRepository;
using Domain.Utilities;
using Service.Abstraction.IDataServices;
using Service.Abstraction.IExternalServices;
using Service.Extentions;
using Service.ExternalServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataServices
{
    public class PostService : IPostService
    {
        public readonly IAdminDataRepository _adminDataRepository;
        public readonly IExternalService _externalService;
        public PostService(IAdminDataRepository adminDataRepository, IExternalService externalService) 
        { 
           _adminDataRepository = adminDataRepository;
            _externalService = externalService;
        }    
        public async Task<Guid> Add(AddPostDto Dto)
        {
            var Post =  Dto.ToPost();
            await _adminDataRepository.PostRepository.Add(Post);
            await _adminDataRepository.SaveChangesAsync();
            int i = 0;
            if (Post.Images!=null)
                foreach (var image in Post.Images)
                {
                    var path = Path.Combine(Dto.AcademyId, Post.Id.ToString(),ConfigUtility.Image ,i.ToString());
                    await _externalService.FileService.SaveImage(path, image);
                    Post.Images.Add(path);                 
                    i++;
                }
            await _adminDataRepository.PostRepository.Update(Post);
            await _adminDataRepository.SaveChangesAsync();
            return Post.Id;
        }

        public async Task<string> Add(CommentDto Dto,string Type)
        {
            var Comment = Dto.ToComment(Type);
            await _adminDataRepository.CommentRepository.Add(Comment);
            await _adminDataRepository.SaveChangesAsync();
            var path = "";
            if (Type != "Text") {
                path = Path.Combine(Dto.AcademyId, Dto.PostId, ConfigUtility.CommentFolderName,Comment.Id.ToString());
                await _externalService.FileService.SaveImage(path, Dto.Message);
                Comment.Value = path;
                await _adminDataRepository.CommentRepository.Update(Comment);
                await _adminDataRepository.SaveChangesAsync();
            }
            return path;
        }

        public async Task<string> Add(CommentReplyDto Dto, string Type)
        {
            var CommentReply = Dto.ToCommentReply(Type);
            await _adminDataRepository.CommentRepository.Add(CommentReply);
            await _adminDataRepository.SaveChangesAsync();
            var Comment = await _adminDataRepository.CommentRepository.Get(Guid.Parse(Dto.CommentId));
            if (Comment == null)
            {
                var CommentReplyDelete = await _adminDataRepository.CommentRepository.Get(CommentReply.Id);
                await _adminDataRepository.CommentRepository.Delete(CommentReplyDelete);
                await _adminDataRepository.SaveChangesAsync();
                throw new Exception("Original Comment Not found");
            }
            if (Comment?.Replies  == null)
            {
                Comment.Replies = new List<Message>();
            }
            Comment?.Replies?.Add(CommentReply);
            await _adminDataRepository.CommentRepository.Update(Comment);
            await _adminDataRepository.SaveChangesAsync();
            var path = "";
            if (Type != "Text") { 
                 path = Path.Combine(Dto.AcademyId, Dto.PostId, ConfigUtility.CommentFolderName, CommentReply.Id.ToString());
                await _externalService.FileService.SaveImage(path, Dto.Message);
                CommentReply.Value =path;
                await _adminDataRepository.CommentRepository.Update(CommentReply);
                await _adminDataRepository.SaveChangesAsync();
            }
            return path;
        }

        public async Task DeleteComment(Guid CommentId)
        {
            var CommentReplyDelete = await _adminDataRepository.CommentRepository.Get(CommentId);
            await _adminDataRepository.CommentRepository.Delete(CommentReplyDelete);
            await _adminDataRepository.SaveChangesAsync();
        }

        public async Task DeletePost(Guid PostId)
        {
            var post = await _adminDataRepository.PostRepository.Get(PostId);
            await _adminDataRepository.PostRepository.Delete(post);
            await _adminDataRepository.SaveChangesAsync();
        }
        public async Task DeletePostImage(Guid PostId,int Index)
        {
            var post = await _adminDataRepository.PostRepository.Get(PostId);
            if (post == null)
            {
                throw new Exception("Post Not found");
            }
            post?.Images?.Remove(post?.Images?.ElementAt(Index)??"");
            await _adminDataRepository.PostRepository.Update(post);
            await _adminDataRepository.SaveChangesAsync();
        }
        public async Task<GetPostDto> Get(Guid Id)
        {

            var post = await _adminDataRepository.PostRepository.Get(Id);
            return post.ToPostDto();
        } 

        public async Task<ICollection<GetPostDto>> GetAll()
        {
            var posts = await _adminDataRepository.PostRepository.GetAll();
            var UserPost = posts.OrderByDescending(p => p.AddingDate).ToList();
            return posts.ToPostDto();
        }

        public async Task<ICollection<GetPostDto>> GetAllByUser(string Id)
        {
            var posts = await _adminDataRepository.PostRepository.GetAll();
            var UserPost = posts.Where(p => p.UserId == Id).ToList();
            return UserPost.ToPostDto();
        }

        public async Task<ICollection<GetCommentDto>> GetAllCommentOfPost(Guid Id)
        {
            var Comments = await _adminDataRepository.CommentRepository.GetAll();          
            var Des = Comments.OrderByDescending(p => p.AddingDate).ToList();
            foreach (var item in Des)
            {
                if (item.Type != Domain.Enums.MessageType.Text)
                {
                    // Ensure the directory exists
                    if (!File.Exists(item.Value))
                    {
                        throw new NotFoundException("The cve directory does not exist.");
                    }
                    
                    byte[] imageBytes = System.IO.File.ReadAllBytes(item.Value);

                    
                    string base64String = Convert.ToBase64String(imageBytes);
                    item.Value = base64String;
                }
            }
            return Des.ToCommentDto();
        }

        public async Task<ICollection<GetPostDto>> GetAllPostOfAcademy(Guid Id)
        {
            var posts = await _adminDataRepository.PostRepository.GetAll();
            // edit with academy id
            var UserPost = posts.OrderByDescending(p => p.AddingDate).Where(p=>p.Id == Id).ToList();
            return posts.ToPostDto();
        }

        public async Task<ICollection<GetPostDto>> GetAllPublic()
        {
            var posts = await _adminDataRepository.PostRepository.GetAll();
            var UserPost = posts.Where(p => p.IsPublic == true).ToList();
            return UserPost.ToPostDto();
        }

        

        public async Task UpdateComment(UpdateComment Dto)
        {
            var Comment = await _adminDataRepository.CommentRepository.Get(Dto.CommentId);
            if (Comment == null)
                throw new Exception("This comment Not Found");
            Comment.Value = Dto.Value;
            await _adminDataRepository.CommentRepository.Update(Comment);
            await _adminDataRepository.SaveChangesAsync();
        }

        
        public async Task UpdatePost(UpdatePostDto Dto)
        {
            var post = await _adminDataRepository.PostRepository.Get(Dto.PostId);
            if (post == null)
                throw new Exception("This post Not Found");
            post.Title = Dto.Title;
            post.Description = Dto.Description;
            post.IsPublic =Dto.IsPublic;
           // post.Images  = Dto.Images;
            await _adminDataRepository.PostRepository.Update(post);
            await _adminDataRepository.SaveChangesAsync();
        }
        public async Task UpdatePost(UpdatePostImagesDto Dto)
        {
            var post = await _adminDataRepository.PostRepository.Get(Dto.PostId);
            if (post == null)
                throw new Exception("This post Not Found");
            foreach (var image in Dto?.Images?? [])
            {
                post?.Images?.Add(image);
            }
            //post.Images  = Dto.Images;
            await _adminDataRepository.PostRepository.Update(post);
            await _adminDataRepository.SaveChangesAsync();
        }

        /// update and delete images from posts Handling
        /// save Images Path
    }
}
