using BusinessObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDTO>> GetCommentsAsync();
        Task<CommentDTO> GetCommentAsync(int id);
        Task<IEnumerable<CommentDTO>> GetCommentsByProductIDAsync(int productID);
        Task<CommentDTO> CreateCommentAsync(CommentDTO commentDTO);
        Task<CommentDTO> UpdateCommentAsync(int id, CommentDTO commentDTO);
        Task ToggleCommentStatusAsync(int id, bool status);
        Task DeleteCommentAsync(int id);
    }
}
