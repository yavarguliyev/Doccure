using Api.Extensions;
using Core.DTOs.Main;
using Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Main
{
    public class BlogController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] BlogParams blogParams)
        {
            var blogs = await BlogService.GetAsync(blogParams);
            var blogsDto = Mapper.Map<IEnumerable<BlogDTO>>(blogs);

            Response.AddPagination(blogs.CurrentPage, blogs.PageSize, blogs.TotalCount, blogs.TotalPages);

            return Ok(blogsDto);
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> Details(string slug) => Ok(await BlogService.GetAsync(slug));
    }
}