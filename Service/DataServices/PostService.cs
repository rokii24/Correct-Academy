using Contract.AddDtos;
using Contract.GetDtos;
using Contract.HubDtos;
using Domain.Entities.DataEntities;
using Domain.IRepositories.DataRepository;
using Service.Abstraction.IDataServices;
using Service.Extentions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataServices
{
    public class PostService : IPostService
    {
        public readonly IAdminDataRepository _adminDataRepository;
        public PostService(IAdminDataRepository adminDataRepository) 
        { 
           _adminDataRepository = adminDataRepository;
        }    
        public async Task Add(AddPostDto Dto)
        {
            var Post =  Dto.ToPost();
            await _adminDataRepository.PostRepository.Add(Post);
        }

        public async Task Add(CommentDto Dto,string Type)
        {
            var Comment = Dto.ToComment(Type);
            await _adminDataRepository.CommentRepository.Add(Comment);
        }

        public async Task Add(CommentReplyDto Dto, string Type)
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

        public async Task<ICollection<GetPostDto>> GetAll()
        {
            var posts = await _adminDataRepository.PostRepository.GetAll();
            return posts.ToPostDto();
        }

        public async Task<ICollection<GetPostDto>> GetAllByUser(string Id)
        {
            var posts = await _adminDataRepository.PostRepository.GetAll();
            var UserPost = posts.Where(p => p.UserId == Id).ToList();
            return UserPost.ToPostDto();
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
            post.Images  = Dto.Images;
            await _adminDataRepository.PostRepository.Update(post);
            await _adminDataRepository.SaveChangesAsync();
        }


        /// update and delete images from posts Handling
        /// save Images Path
    }
}
