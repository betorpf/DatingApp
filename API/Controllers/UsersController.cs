using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers {
    [Authorize]
    public class UsersController : BaseApiController {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController (IUserRepository userRepository, IMapper mapper) {
            this._mapper = mapper;
            this._userRepository = userRepository;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers () {
            // var users = await _userRepository.GetUsersAsync();
            // var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
            var usersToReturn = await  _userRepository.GetMembersAsync();
            return Ok (usersToReturn);
        }

        [HttpGet ("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser (string username) {
            // var user = await _userRepository.GetUserByUsernameAsync(username);
            // return _mapper.Map<MemberDto>(user);
            return  await _userRepository.GetMemberAsync(username);
        }

    }

}
