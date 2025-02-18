using Login_Register.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Login_Register.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserContext _context;
        private readonly UserStore _userStore;
        public UserController(UserContext context, UserStore store) 
        { 
        _context = context;
        _userStore = store;
        
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        //GET api/<UserController>
        [HttpPost("loginRequest")]
        public async Task<IActionResult> loginRequest([FromBody] UserLogin user) {
            try

            {
                if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
                {
                    return BadRequest(new { success = false });
                }
                var userDB = await _userStore.FindByEmailAsync(user.Email);
                if (userDB == null || userDB.Password != user.Password)
                {
                    return Unauthorized(new { success = false, message = "Email ou senha incorretos" });
                }
                return Ok(new { success = true, message = "login autorizado" });
            }
            catch(Exception ex) 
            {

                return StatusCode(500, new { success = false, message = "Erro interno do servidor" });

            }
           

        }



        // POST api/<UserController> 
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] User user) 
        {

            if (!ModelState.IsValid) 
            { 
            return BadRequest(ModelState);
                
            }
            await _userStore.CreateAsync(user);
            return Ok(user);
        }
        
    }
}
