using BilgeBlog.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeBlog.Business.Services
{
    public interface IPostService
    {
        void AddPost(PostAddDto postAddDto);

        List<PostListDto> GetAll();

        void DeletePost(int id);

        PostUpdateDto GetPostById(int id);

        void UpdatePost(PostUpdateDto postUpdateDto);

        PostDetailDto GetPostDetail(int id);

    }
}
