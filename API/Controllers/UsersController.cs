using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await _userRepository.GetMembersAsync();

            
            return Ok(users);
        }
        
        // [HttpGet("{id}")]
        // public async Task<ActionResult<MemberDto>> GetUserById(int id)
        // {
        //     var user = await _userRepository.GetUserByIdAsync(id);
        //     var member =_mapper.Map<MemberDto>(user);
        //     return Ok(member);
        // }

        [HttpGet("{userName}")]
        public async Task<ActionResult<MemberDto>> GetUserByName(string userName)
        {
            var user = await _userRepository.GetMemberAsync(userName);
            
            return Ok(user);
        }
    }
}
