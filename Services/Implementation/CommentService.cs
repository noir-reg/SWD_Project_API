using BusinessObjects.DTOs;
using BusinessObjects.Models;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<CommentDTO>> GetCommentsAsync()
        {
            var comments = await _commentRepository.GetCommentsAsync();
            return comments.Select(c => new CommentDTO(c));
        }

        public async Task<CommentDTO> GetCommentAsync(int id)
        {
            var comment = await _commentRepository.GetCommentAsync(id);
            return comment != null ? new CommentDTO(comment) : null;
        }
        public async Task<IEnumerable<CommentDTO>> GetCommentsByProductIDAsync(int productID)
        {
            var comments = await _commentRepository.GetCommentsByProductIDAsync(productID);
            return comments.Select(c => new CommentDTO(c));
        }       

        public async Task<CommentDTO> CreateCommentAsync(CommentDTO commentDTO)
        {
            var comment = new Comment
            {
                UserId = commentDTO.UserId,
                ProductId = commentDTO.ProductId,
                Content = commentDTO.Content,
                CommentDate = DateTime.Now,
                Rate = commentDTO.Rate,
                Status = commentDTO.Status
            };
            await _commentRepository.CreateCommentAsync(comment);
            return new CommentDTO(comment);
        }

        public async Task<CommentDTO> UpdateCommentAsync(int id, CommentDTO commentDTO)
        {
            var comment = await _commentRepository.GetCommentAsync(id);
            if (comment != null)
            {
                comment.UserId = commentDTO.UserId;
                comment.ProductId = commentDTO.ProductId;
                comment.Content = commentDTO.Content;
                comment.Rate = commentDTO.Rate;
                comment.Status = commentDTO.Status;
                await _commentRepository.UpdateCommentAsync(id, comment);
                return new CommentDTO(comment);
            }
            return null;
        }
        public async Task ToggleCommentStatusAsync(int id, bool status)
        {
            var comment = await _commentRepository.GetCommentAsync(id);
            if (comment != null)
            {
                comment.Status = status;
                await _commentRepository.ToggleCommentStatusAsync(id, comment);
            }
        }

        public async Task DeleteCommentAsync(int id)
        {
            await _commentRepository.DeleteCommentAsync(id);
        }

        
    }
}
