using BusinessObjects.DTOs;
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
    public class PostRepository : IPostRepository
    {
        private readonly MilkShopContext _context = new();
        
        public bool CreatePost(CreatePostRequest createProductRequest)
        {
            _context.Posts.Add(new Post
            {
                Author = createProductRequest.Author,
                BriefContent = createProductRequest.BriefContent,
                CreatedDate = DateTime.Now,
                LastModified = DateTime.Now,
                Title = createProductRequest.Title,
                TagSearch = createProductRequest.TagSearch,
                Status = true,               
            });
            if (_context.SaveChanges() >= 1)
                return true;
            return false;
        }

        public bool DeletePost(int id)
        {
            var post = _context.Posts.Where(x => x.PostId == id).FirstOrDefault();
            if (post == null)
                return false; 

            _context.Posts.Remove(post);

            return _context.SaveChanges() >= 1;
        }

        public IEnumerable<PostResponse> FilterbyTag(string tag)
        {
            return _context.Posts
                .Where(p => p.TagSearch.Equals(tag) && p.Status == true)
                .Select(p => new PostResponse
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    CreatedDate = p.CreatedDate,
                    LastModified = p.LastModified,
                    TagSearch = p.TagSearch,
                    Author = _context.Accounts.Where(a => a.Id == p.Author.Value).FirstOrDefault().Fullname
                }).ToList();
        }

        public IEnumerable<PostResponse> GetAllPosts()
        {
            return _context.Posts
                .Where(p => p.Status == true)
                 .Select(p => new PostResponse
                 {
                     PostId = p.PostId,
                     Title = p.Title,
                     CreatedDate = p.CreatedDate,
                     LastModified = p.LastModified,
                     TagSearch = p.TagSearch,
                     Author = _context.Accounts.Where(a => a.Id == p.Author.Value).FirstOrDefault().Fullname
                 }).ToList();
        }

        public Post GetPostByID(int id)
        {
            return _context.Posts.Where(x => x.PostId == id && x.Status == true).FirstOrDefault();
        }

        public IEnumerable<PostResponse> SearchPosts(string keyword)
        {
            return _context.Posts
                .Where(p => p.Title.Contains(keyword) && p.Status == true)
                .Select(p => new PostResponse
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    CreatedDate = p.CreatedDate,
                    LastModified = p.LastModified,
                   TagSearch = p.TagSearch,
                   Author = _context.Accounts.Where(a => a.Id == p.Author.Value).FirstOrDefault().Fullname
                }).ToList();
        }

        public bool UpdatePost(UpdatePostRequest updatePost)
        {
            var post = _context.Posts.FirstOrDefault(x => x.PostId == updatePost.Id);
            if (post == null)
                return false;

            if (updatePost.Title != null)
                post.Title = updatePost.Title;

            if (updatePost.BriefContent != null)
                post.BriefContent = updatePost.BriefContent;

            if (updatePost.TagSearch != null)
                post.TagSearch = updatePost.TagSearch;

            if (updatePost.Status != null)
                post.Status = updatePost.Status;

                post.LastModified = DateTime.Now;            

            if (_context.SaveChanges() >= 1)
                return true;

            return false;
        }
    }
}
