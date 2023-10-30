using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public readonly WebAPIContext _context;

        public BaseController(WebAPIContext context)
        {
            _context = context;
        }

        public string? UserId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier);

            }
        }

        public DemoUser CurrentUser
        {
            get
            {
                return _context.Users.Single(u => u.Id == UserId);

            }
        }
    }
}
