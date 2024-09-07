﻿using Domain.IRepositories.DataRepositories;
using Domain.IRepositories.DataRepository;
using Persistence.Context;
using Persistence.Reposetories.DataReposatoiry;
//using Persistence.Reposetories.DAtaReposatoiry;


namespace Persistence.Repositories.DataRepository
{
    public class AdminDataRepository : IAdminDataRepository
    {
        private readonly CorrectAcademyContext _context;
        private IPostRepository _postRepository = null!;
        private ICommentRepository _commentRepository = null!;

        public AdminDataRepository(CorrectAcademyContext context) => _context = context;

        public IPostRepository PostRepository
        {
            get
            {
                if (_postRepository == null)
                    _postRepository = new PostRepository(_context);

                return _postRepository;
            }
        }
        public ICommentRepository CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                    _commentRepository = new CommentRepository(_context);

                return _commentRepository;
            }
        }

      

        public int SaveChanges() => _context.SaveChanges();
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
