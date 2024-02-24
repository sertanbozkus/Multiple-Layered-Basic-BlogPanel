using BilgeBlog.Business.Dtos;
using BilgeBlog.Business.Services;
using BilgeBlog.Data.Entities;
using BilgeBlog.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeBlog.Business.Managers
{
    public class PostManager : IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostManager(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public void AddPost(PostAddDto postAddDto)
        {

            var postEntity = new PostEntity()
            {
                Title = postAddDto.Title,
                Summary = postAddDto.Summary,
                Content = postAddDto.Content,
                CategoryId = postAddDto.CategoryId
            };

            _postRepository.AddPost(postEntity);

           

        }

        public void DeletePost(int id)
        {

            _postRepository.DeletePost(id);
        }

        public List<PostListDto> GetAll()
        {
            var postsQuery = _postRepository.GetAll().OrderBy(x => x.Title);

            var postDtoList = postsQuery.Select(x => new PostListDto()
            {
                Id = x.Id,
                Title = x.Title,
                Summary = x.Summary,
                CategoryName = x.Category.Name
            }).ToList();


            return postDtoList;
        }

        public PostUpdateDto GetPostById(int id)
        {
            var postEntity = _postRepository.GetPostById(id);

            var postUpdateDto = new PostUpdateDto()
            {
                Id = postEntity.Id,
                Title = postEntity.Title,
                Summary = postEntity.Summary,
                Content = postEntity.Content,
                CategoryId = postEntity.CategoryId
            };

            return postUpdateDto;
        }

        public PostDetailDto GetPostDetail(int id)
        {
            var postEntity = _postRepository.GetPostById(id);

            var postDetailDto = new PostDetailDto()
            {
                Id = postEntity.Id,
                Title = postEntity.Title,
                Summary = postEntity.Summary,
                Content = postEntity.Content,
            };

            return postDetailDto;
        }

        public void UpdatePost(PostUpdateDto postUpdateDto)
        {
            var postEntity = _postRepository.GetPostById(postUpdateDto.Id);

            postEntity.Title = postUpdateDto.Title;
            postEntity.Summary = postUpdateDto.Summary;
            postEntity.Content = postUpdateDto.Content;
            postEntity.CategoryId = postUpdateDto.CategoryId;
            

            _postRepository.UpdatePost(postEntity);
        }
    }
}
