using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Admin.Directory.directory_v1.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;

using trainingproject.Models;
using User = trainingproject.Models.User;

namespace trainingproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BooksContext _context;





        public UsersController(BooksContext context)
        {
            _context = context;

        }

        //get
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Getusers()
        {
            return await _context.Users.ToListAsync();
        }


        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromForm] UserModel user)
        {
            if (user.Profilepic == null)
            {
                return new UnsupportedMediaTypeResult();
            }

            if (user.Profilepic.Length > 0)
            {
                IFormFile formFile = user.Profilepic;

                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload");

                var filePath = Path.Combine(folderPath, formFile.FileName);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                    fileStream.Flush();
                    //return Ok(new { status = "Upload Success", length = formFile.Length, name = formFile.FileName });
                }
            }


            User user1 = new User();
            user1.UserName = user.UserName;
            user1.UserId = user.UserId;
            user1.Email = user.Email;
            user1.Gender = user.Gender;
            user1.Mobile = user.Mobile;
            user1.Hobbies = user.Hobbies;
            user1.Dob = user.Dob;
            user1.Profile_pic = user.Profilepic.Name;


            _context.Users.Add(user1);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUser", new { id = user.UserId }, user);

        }
    }
}
