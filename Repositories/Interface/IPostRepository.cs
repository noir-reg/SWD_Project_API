using BusinessObjects.DTOs;
using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IPostRepository
    {
        public Post GetPostByID(int id);
        public bool CreatePost(CreatePostRequest createProductRequest);
        public bool UpdatePost(UpdatePostRequest updateProductRequest);
        public bool DeletePost(int id);
        IEnumerable<PostResponse> SearchPosts(string keyword);
        IEnumerable<PostResponse> FilterbyTag(string tag);
        IEnumerable<PostResponse> GetAllPosts();
    }
}
