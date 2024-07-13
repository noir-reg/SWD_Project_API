using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MilkShopContext _context = new();

        public async Task<IEnumerable<Comment>> GetCommentsAsync()
        {
            return await _context.Comments.Include(x=>x.User).ToListAsync();
        }

        public async Task<Comment> GetCommentAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }
        public async Task<IEnumerable<Comment>> GetCommentsByProductIDAsync(int productID)
        {
            return await _context.Comments
                .Where(c => c.ProductId == productID).Include(x => x.User)
                .ToListAsync();
        }

        public async Task<Comment> CreateCommentAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> UpdateCommentAsync(int id, Comment comment)
        {
            var existingComment = await _context.Comments.FindAsync(id);
            if (existingComment != null)
            {
                existingComment.UserId = comment.UserId;
                existingComment.ProductId = comment.ProductId;
                existingComment.Content = comment.Content;
                existingComment.CommentDate = DateTime.Now;
                existingComment.Rate = comment.Rate;
                existingComment.Status = comment.Status;
                await _context.SaveChangesAsync();
                return existingComment;
            }
            return null;
        }

        public async Task DeleteCommentAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ToggleCommentStatusAsync(int id, Comment comment)
        {
            var existingComment = await _context.Comments.FindAsync(id);
            if (existingComment != null)
            {
                existingComment.Status = comment.Status;
                await _context.SaveChangesAsync();
            }
        }
    }
}
