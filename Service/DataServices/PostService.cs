using Contract.AddDtos;
using Contract.GetDtos;
using Contract.HubDtos;
using Domain.IRepositories.DataRepository;
using Service.Abstraction.IDataServices;
using Service.Extentions;
using System;
using System.Collections.Generic;
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

        public Task Add(CommentDto Dto)
        {
            throw new NotImplementedException();
        }

        public Task Add(CommentReplyDto Dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteComment(Guid CommentId)
        {
            throw new NotImplementedException();
        }

        public Task DeletePost(Guid PostId)
        {
            throw new NotImplementedException();
        }

        public ICollection<GetPostDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<GetPostDto> GetAllByUser(string Id)
        {
            throw new NotImplementedException();
        }

        public ICollection<GetPostDto> GetAllPublic()
        {
            throw new NotImplementedException();
        }

        public Task UpdateComment(Guid CommentId)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePost(Guid CommentId)
        {
            throw new NotImplementedException();
        }
    }
}
