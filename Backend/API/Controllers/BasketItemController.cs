using API.Dtos;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/basket")]
    [ApiController]
    public class BasketItemController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public BasketItemController(ApplicationDbContext DbContext, IMapper mapper)
        {
            _dbContext = DbContext;
            _mapper = mapper;
        }

        // Get, Post, Delete.

         /*
          * [HttpGet]
          * [HttpPost]
          * [HttpDelete]
         */
    }
}
