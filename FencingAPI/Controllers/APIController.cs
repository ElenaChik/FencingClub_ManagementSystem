using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FancingClubManagementSystemProject.Model;
using FancingClubManagementSystemProject.DAO;
using System.Numerics;

namespace FencingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {

        [HttpPost(Name = "addMember")]
        public IActionResult AddMember(Member memb)
        {
            var dao = new MemberDAO();
            dao.addMember(memb.nameFirst, memb.nameLast, memb.dateBirth,
                memb.phone, memb.email, memb.licenceNumber, memb.dateLicenceExpire);

            return Ok();
         
        }
    }
}
