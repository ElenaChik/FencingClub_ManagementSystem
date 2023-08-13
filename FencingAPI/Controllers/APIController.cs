using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FancingClubManagementSystemProject.Model;
using FancingClubManagementSystemProject.DAO;
using FancingClubManagementSystemProject.Service;
using System.Numerics;
using SharedLogic.DAO;
using SharedLogic.Model;
using System.Data;

namespace FencingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public APIController(IConfiguration configuration)
        {
            /*
           *The IConfiguration in this constructor space is going to be invoked when
           * the class instance is created.This is going to to grab the connection from
           * the appsettings and then going to send it back the configuration object
           * or instance of this scope;
           * ex:  NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("studentConnection").ToString());
            */
            _configuration = configuration;
        }



        
       

        [HttpPost]
        [Route("addRegistration")]
        public IActionResult AddRegistration(Registration reg)
        {
             var fs = new FensingService();
             fs.addRegistration(reg.name, reg.contact, reg.startDate, reg.age);

            return Ok();
        }

        


        [HttpGet]
        [Route("getAllRegistration")]
        public DataTable getAllRegistration()   //......
        {
            /*
            Response response = new Response();
            NpgsqlConnection con = new NpgsqlConnection(_configuration.GetConnectionString("studentConnection").ToString());
            Applications app = new Applications();
            response = app.GetAllStudents(con);
            return response; 
        
            */
            var dao = new RegistrationDAO();
            var table = dao.getAllRegistration();
         
            return table;
        }

        [HttpPost]
        [Route("addMember")]
        public IActionResult AddMember(Member memb)
        {
            var fs = new FensingService();
            fs.addMember(memb.nameFirst, memb.nameLast, memb.dateBirth,
                memb.phone, memb.email, memb.licenceNumber, memb.dateLicenceExpire);

            return Ok();
        }

        [HttpDelete]
        [Route("deleteMemberById")]
        public IActionResult deleteMember(string id)
        {
            var fs = new FensingService();
            fs.deleteMemberById(id);

            return Ok();
        }

        [HttpPut]
        [Route("updateMemberById/{id}")]
        public IActionResult updateMemberById(Member memb, string id)   //.........
        {
            var fs = new FensingService();
            fs.updateMemberById(memb.nameFirst, memb.nameLast, memb.dateBirth,
                memb.phone, memb.email, memb.licenceNumber, memb.dateLicenceExpire, memb.group, memb.coach, id);

            return Ok();
        }


        [HttpGet]
        [Route("getMemberById")]
        public Member getMemberById(string id)
        {
            var fs = new FensingService();
            Member member = fs.getMemberInfoById(id);

            return member;
        }
    }
}
