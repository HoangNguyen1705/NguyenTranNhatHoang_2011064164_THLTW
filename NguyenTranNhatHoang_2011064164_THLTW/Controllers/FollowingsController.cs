using Microsoft.AspNet.Identity;
using NguyenTranNhatHoang_2011064164_THLTW.DTOs;
using NguyenTranNhatHoang_2011064164_THLTW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NguyenTranNhatHoang_2011064164_THLTW.Controllers
{
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext dbcontext;
        public FollowingsController()
        {
            dbcontext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (dbcontext.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == followingDto.FolloweeId))
            {
                return BadRequest("Following already exists !");
            }
            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = followingDto.FolloweeId
            };
            dbcontext.Followings.Add(following);
            dbcontext.SaveChanges();
            return Ok();
        }
    }
}
