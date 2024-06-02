using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetCommentsAsync();
        Task<Comment> GetCommentAsync(int id);
        Task<IEnumerable<Comment>> GetCommentsByProductIDAsync(int productID);
        Task<Comment> CreateCommentAsync(Comment comment);
        Task<Comment> UpdateCommentAsync(int id, Comment comment);
        Task ToggleCommentStatusAsync(int id, Comment comment);
        Task DeleteCommentAsync(int id);
    }
}
