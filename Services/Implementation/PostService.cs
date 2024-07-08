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
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;
        public PostService(IPostRepository repository)
        {
            _repository = repository;
        }
        public bool CreatePost(CreatePostRequest createPostRequest)
        {
            return _repository.CreatePost(createPostRequest);
        }

        public bool DeletePost(int id)
        {
            return _repository.DeletePost(id);
        }

        public IEnumerable<PostResponse> FilterbyTag(string tag)
        {
            return _repository.FilterbyTag(tag);
        }

        public IEnumerable<PostResponse> GetAllPosts()
        {
            return _repository.GetAllPosts();
        }

        public Post GetPostByID(int id)
        {
            return _repository.GetPostByID(id);
        }

        public IEnumerable<PostResponse> SearchPosts(string keyword)
        {
            return _repository.SearchPosts(keyword);
        }

        public bool UpdatePost(UpdatePostRequest updatePostRequest)
        {
            return _repository.UpdatePost(updatePostRequest);
        }
    }
}
