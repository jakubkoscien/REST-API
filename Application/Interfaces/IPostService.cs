﻿using Application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPostService
    {
        IEnumerable<PostDTO> GetAllPosts();
        PostDTO GetPostById(int id);
        PostDTO AddNewPost(CreatePostDTO post);
        void UpdatePost(UpdatePostDTO updatePost);
        void DeletePost(int id);

    }
}
