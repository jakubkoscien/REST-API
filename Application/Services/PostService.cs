using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public IEnumerable<PostDTO> GetAllPosts()
        {
            var posts = _postRepository.GetAll();
            return _mapper.Map<IEnumerable<PostDTO>>(posts);
        }

        public PostDTO GetPostById(int id)
        {
            var post = _postRepository.GetById(id);
            return _mapper.Map<PostDTO>(post);
        }

        public PostDTO AddNewPost(CreatePostDTO newPost)
        {
            if(string.IsNullOrEmpty(newPost.Title))
            {
                throw new Exception("Post can not have an empty title.");
            }

            var post = _mapper.Map<Post>(newPost);
            _postRepository.Add(post);
            return _mapper.Map<PostDTO>(post);
        }

        public void UpdatePost(UpdatePostDTO updatePost)
        {
            var existingPost = _postRepository.GetById(updatePost.Id);
            var post = _mapper.Map(updatePost, existingPost);
            _postRepository.Update(post);
        }

        public void DeletePost(int id)
        {
            var post = _postRepository.GetById(id);
            _postRepository.Delete(post);
        }
           
    }
}
